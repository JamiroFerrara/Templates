using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _wpf48.Utility
{
    public class KeybindHelper
    {
        private object Context;
        private Dictionary<Key, string> MethodMap;

        public KeybindHelper(object context, Dictionary<Key, string> methodMap)
        {
            this.MethodMap = methodMap;
            this.Context = context;

            MapKeyBindings();
        }
        public bool MapKeyBindings()
        {
            if (MethodMap != null && Context != null)
            {
                List<ICommand> commands = new List<ICommand>(MethodMap.Count());
                for (int i = 0; i < MethodMap.Count; i++)
                {
                    commands.Add(new RelayCommand(x => { }, y => true));
                }

                var methods = Context.GetType().GetMethods();

                foreach (var map in MethodMap)
                {
                    foreach (var method in methods)
                    {
                        if (method.Name.ToUpper() == map.Value.ToUpper())
                        {
                            for (int i = 0; i < commands.Count; i++)
                            {
                                commands[i] = new RelayCommand(a =>
                                {
                                    method.Invoke(Context, null);
                                }, o => true);
                            }
                        }
                    }

                    var properties = GetKeyBindType(Context.GetType()).GetProperties();
                    foreach (var command in commands)
                    {
                        foreach (var property in properties)
                        {
                            if (property.PropertyType == typeof(ICommand))
                            {
                                if (property.Name == map.Key.ToString())
                                {
                                    property.SetValue(Context, command);
                                }
                            }
                        }
                    }
                };

                return true;
            }
            else
            {
                return false;
            }
        }
        public void ClearKeyBindings()
        {
            if (Context != null)
            {
                var properties = GetKeyBindType(Context.GetType()).GetProperties();
                foreach (var property in properties)
                {
                    if (property.PropertyType == typeof(ICommand))
                    {
                        property.SetValue(Context, new RelayCommand(x => { }, y => true));
                    }
                }
            }
        }

        private Type GetKeyBindType(Type type)
        {
            for (var current = type; current != null; current = current.BaseType)
            {
                if (current.Name == nameof(BaseKeyBindModel))
                    return current;
            }
            return null;
        }
    }
}

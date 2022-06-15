using System.Windows.Input;

namespace _wpf48
{
    /// <summary>
    /// This is the keybind extension helper. 
    /// Probably needs to be expanded but good enough for now!
    /// </summary>
    public class BaseKeyBindModel
    {
        public ICommand F { get; set; }
        public ICommand H { get; set; }
        public ICommand N { get; set; }
        public ICommand L { get; set; }
        public ICommand Tab { get; set; }
        public ICommand Esc { get; set; }
        public ICommand Up { get; set; }
        public ICommand Down { get; set; }
        public ICommand Left { get; set; }
        public ICommand Right { get; set; }
        public ICommand F5 { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace _wpf48
{
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter where T : class, new()
    {
        private static T mConverter = null;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return mConverter ?? (mConverter = new T());
        }

        public abstract object Convert(object value, System.Type targetType, object parameter, CultureInfo culture);
        public abstract object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture);
    }
}

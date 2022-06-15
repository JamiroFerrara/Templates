using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _wpf48
{
    public class BaseViewModel : BaseKeyBindModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        public event EventHandler<ApplicationPage> PageChangeRequestEvent = (sender, e) => { };

        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        public void RequestPage(ApplicationPage page)
        {
            PageChangeRequestEvent(this, page);
        }
    }
}

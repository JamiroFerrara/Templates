using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _wpf48
{
    public class MainWindowViewModel
    {
        private static ApplicationPage DefaultPage { get; set; } = ApplicationPage.Main;
        public Navigator Navigator { get; set; } = Navigator.Instance = new Navigator(DefaultPage);
    }
}

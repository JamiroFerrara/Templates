using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using _wpf48.Views;

namespace _wpf48
{
    public class Navigator : BaseModel
    {
        public event EventHandler<Page> PageChangedEvent = (sender, e) => { };

        #region Singleton pattern
        private static Navigator _instance;
        public static Navigator Instance { get { return _instance; } set { _instance = value; } }
        #endregion

        //This is Binded to the Main Window Frame 
        private Page currentPage;
        public Page CurrentPage
        {
            get { return currentPage; }
            set { PageChangedEvent(this, value); currentPage = value; }
        }

        public Navigator(ApplicationPage applicationPage)
        {
            SetCurrentPage(applicationPage);
        }

        #region Private Helpers
        private Page SetCurrentPage(ApplicationPage applicationPage)
        {
            Page page = new Page();

            switch (applicationPage)
            {
                case ApplicationPage.Main:
                    page = GetMainPage();
                    break;
            }

            //InitPageChangeRequestListeners(page);

            CurrentPage = page;
            return CurrentPage;
        }

        private void InitPageChangeRequestListeners(Page page)
        {
            (page.DataContext as BaseViewModel).PageChangeRequestEvent -= NavigationService_PageChangeRequestEvent;
            (page.DataContext as BaseViewModel).PageChangeRequestEvent += NavigationService_PageChangeRequestEvent;
        }
        private void NavigationService_PageChangeRequestEvent(object sender, ApplicationPage e)
        {
            SetCurrentPage(e);
        }
        #endregion

        #region ViewBuilders
        private Page GetMainPage()
        {
            return new MainView();
        }

        #endregion

    }
    public enum ApplicationPage
    {
        Main
    }
}

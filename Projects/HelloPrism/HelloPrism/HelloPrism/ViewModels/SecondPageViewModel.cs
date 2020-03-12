using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloPrism.ViewModels
{
    public class SecondPageViewModel : ViewModelBase, IGuardBackNavigation
    {
        public SecondPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "SecondPage";
        }

        bool canReallyGo = false;

        public bool CanGoBack
        {
            get
            {
                bool result = canReallyGo;
                canReallyGo = true;
                return result;
            }
        }
    }
}

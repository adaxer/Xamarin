using HelloPrism.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace HelloPrism.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }

        public ICommand Page2Command => new DelegateCommand(ShowSecondPage);
        private async void ShowSecondPage()
        {
            await NavigationService.NavigateAsync(nameof(SecondPage));
        }
    }
}

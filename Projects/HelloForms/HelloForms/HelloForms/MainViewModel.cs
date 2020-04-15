using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace HelloForms
{
    public class MainViewModel: BindableObject
    {
        private readonly INavigationService _navigationService;

        public MainViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
        }
        public string Title { get; set; } = "The Main ViewModel";

        public ICommand Page2Command => new Command(o=>ShowPage2());

        private void ShowPage2()
        {
            _navigationService.Navigate("Second");
        }
    }
}
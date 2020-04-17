using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using SmartLibrary.Core.Helpers;
using SmartLibrary.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartLibrary.Core.ViewModels
{
    public class WelcomeViewModel : ViewModelBase
    {
        private readonly IUserService _userService;

        public WelcomeViewModel(INavigationService navigationService, IUserService userService, IEventAggregator eventAggregator) : base(navigationService, eventAggregator)
        {
            Title = "SmartLibrary";
            this._userService = userService;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (_userService.IsLoggedIn && parameters.GetNavigationMode() != NavigationMode.Back)
            {
                NavigationService.NavigateAsync(Names.Navigation.Search);
            }
        }
    }
}

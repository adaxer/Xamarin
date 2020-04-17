using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using SmartLibrary.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmartLibrary.Core.ViewModels
{
    public class StartViewModel : ViewModelBase
    {
        public StartViewModel(INavigationService navigationService, IEventAggregator eventAggregator) : base(navigationService, eventAggregator)
        {
        }

        public ICommand ShowSettingsCommand => new DelegateCommand(()=>Show(Names.Navigation.Settings, true));
        public ICommand ShowSearchCommand => new DelegateCommand(() => Show(Names.Navigation.Search));
        public ICommand ShowNewsCommand => new DelegateCommand(() => Show(Names.Navigation.News));

        public bool IsPresented { get; set; }

        private void Show(string destination, bool modal = false)
        {
            if (modal)
            {
                IsPresented = false;
                EventAggregator.GetEvent<NavigationRequest>().Publish(destination);
            }
            else
            {
                NavigationService.NavigateAsync("/StartPage/NavigationPage/" + destination);
            }
        }
    }
}

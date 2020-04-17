using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLibrary.Core.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }
        protected IEventAggregator EventAggregator { get; private set; }

        public string Title { get; set; }

        public bool IsBusy { get; set; }

        static ViewModelBase _currentViewModel;

        public ViewModelBase(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            NavigationService = navigationService;
            EventAggregator = eventAggregator;
            EventAggregator.GetEvent<NavigationRequest>().Subscribe(DoNavigation);
        }

        private void DoNavigation(string destination)
        {
            if(this == _currentViewModel)
            {
                NavigationService.NavigateAsync(destination);
            }
        }

        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            if (!(this is StartViewModel))
            {
                _currentViewModel = this;
            }
        }

        public virtual void Destroy()
        {

        }
    }
}

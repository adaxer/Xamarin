using HelloCross.Core.Interfaces;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HelloCross.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(IMvxNavigationService navigationService, ILoggerService logger): base(navigationService)
        {
            logger.Info("No parameters");
            Title = "Hello MainViewModel";
            logger.Info("In MainViewModel ctor");
        }

        public ICommand ShowResearchCommand => new MvxCommand(ShowResearch);
        public ICommand ShowQueriesCommand => new MvxCommand(ShowQueries);

        private async void ShowQueries()
        {
            await NavigationService.Navigate<QueriesViewModel>();
        }

        private async void ShowResearch()
        {
            await NavigationService.Navigate<ResearchViewModel>();
        }
    }
}

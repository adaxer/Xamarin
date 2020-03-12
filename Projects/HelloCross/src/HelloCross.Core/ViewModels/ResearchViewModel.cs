using HelloCross.Core.Interfaces;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;

namespace HelloCross.Core.ViewModels
{
    public class ResearchViewModel : BaseViewModel
    {
        private readonly ISettingsService _settings;

        public ResearchViewModel(IMvxNavigationService navigationService, ISettingsService settings) : base(navigationService)
        {
            Title = "Research-ViewModel";
            _settings = settings;
        }

        public string SearchText { get; set; } = "text";

        public ICommand StartSearchCommand => new MvxCommand(StartSearch);

        private async void StartSearch()
        {
            ;
        }

        public override async Task Initialize()
        {
            await base.Initialize();
            if(_settings.Has("Research.SearchText"))
            {
                SearchText = _settings.Get("Research.SearchText", "");
            }
        }
        public override void ViewDisappearing()
        {
            base.ViewDisappearing();
            _settings.Set("Research.SearchText", SearchText);
        }
    }
}

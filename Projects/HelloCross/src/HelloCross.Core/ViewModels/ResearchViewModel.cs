using HelloCross.Core.Interfaces;
using HelloCross.Core.Models;
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
        private readonly IBookService _bookService;

        public ResearchViewModel(IMvxNavigationService navigationService, ISettingsService settings, IBookService bookService) : base(navigationService)
        {
            Title = "Research-ViewModel";
            _settings = settings;
            _bookService = bookService;
        }

        public string SearchText { get; set; } = "text";

        public ICollection<Book> Books { get; set; }

        private BookQuery _lastQuery;

        public int ResultCount { get; set; }

        public ICommand StartSearchCommand => new MvxCommand(StartSearch);
        public ICommand SaveCommand => new MvxCommand(Save);

        private async void Save()
        {
            IsBusy = true;
            await _bookService.SaveQueryAsync(new BookQueryResult { Count = (_lastQuery ?? new BookQuery()).Count, Date = DateTime.UtcNow, SearchText = SearchText });
            IsBusy = false;
        }

        public bool HasResult { get; private set; }
        public string ResultInfo { get; private set; }

        private async void StartSearch()
        {
            IsBusy = true;
            _lastQuery = await _bookService.BookQueryAsync(SearchText);
            ResultCount = _lastQuery.Count;
            Books = new MvxObservableCollection<Book>(_lastQuery.Books);
            IsBusy = false;
            HasResult = _lastQuery.Count > 0;
            ResultInfo = $"{_lastQuery.Count} Book(s) found";
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

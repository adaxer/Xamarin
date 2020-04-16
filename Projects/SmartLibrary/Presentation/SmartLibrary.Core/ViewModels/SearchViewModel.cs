using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SmartLibrary.Core.Helpers;
using SmartLibrary.Core.Interfaces;
using SmartLibrary.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace SmartLibrary.Core.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        private readonly IBookService _bookService;

        public IBookShareClient ShareClient { get; }

        public SearchViewModel(INavigationService navigationService, IBookService bookService, IBookShareClient bookShareClient) : base(navigationService)
        {
            Title = "Search";
            this._bookService = bookService;
            ShareClient = bookShareClient;
        }

        public ICommand SearchCommand => new DelegateCommand(DoSearch);

        public string SearchText { get; set; }

        public ICollection<Book> Books { get; set; }

        private Book _currentBook;

        public Book CurrentBook
        {
            get { return _currentBook; }
            set 
            { 
                _currentBook = value; 
                if(_currentBook!=null)
                {
                    NavigationService.NavigateAsync(Names.Navigation.Details, ("Id", _currentBook.Id));
                }
            }
        }

        public BookQuery LastQuery { get; set; }

        private async void DoSearch()
        {
            IsBusy = true;
            LastQuery = await _bookService.BookQueryAsync(SearchText);
            Books = new ObservableCollection<Book>(LastQuery?.Books);
            IsBusy = false;
        }
    }
}

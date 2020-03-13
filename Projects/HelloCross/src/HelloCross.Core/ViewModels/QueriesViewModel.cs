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

namespace HelloCross.Core.ViewModels
{
    public class QueriesViewModel : BaseViewModel
    {
        private readonly IBookService _bookService;

        public QueriesViewModel(IMvxNavigationService navigationService, IBookService bookService) : base(navigationService)
        {
            _bookService = bookService;
        }

        public IEnumerable<BookQueryResult> Queries { get; private set; }

        private BookQueryResult _currentQuery;

        public BookQueryResult CurrentQuery
        {
            get { return _currentQuery; }
            set { _currentQuery = value; ShowQuery(value); }
        }

        public ICommand ShowQueryCommand => new MvxCommand<BookQueryResult>(bqr => ShowQuery(bqr));

        private async void ShowQuery(BookQueryResult bookQuery)
        {
            if (bookQuery != null)
            {
                await NavigationService.Navigate<ResearchViewModel, string>(bookQuery.SearchText);
            }
        }

        public override async Task Initialize()
        {
            IsBusy = true;
            Queries = await _bookService.GetQueriesAsync();
            IsBusy = false;
        }
    }
}

using HelloCross.Core.Interfaces;
using HelloCross.Core.Models;
using MvvmCross.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public override async Task Initialize()
        {
            IsBusy = true;
            Queries = await _bookService.GetQueriesAsync();
            IsBusy = false;
        }
    }
}

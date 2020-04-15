using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SmartLibrary.Core.Interfaces;
using SmartLibrary.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartLibrary.Core.ViewModels
{
    public class DetailsViewModel : ViewModelBase
    {
        private readonly IBookService _bookService;

        public DetailsViewModel(INavigationService navigationService, IBookService bookService) : base(navigationService)
        {
            this._bookService = bookService;
        }

        public Book Book { get; set; }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.TryGetValue<string>("Id", out string id))
            {
                Title = "Hole Info für Book " + id;
                IsBusy = true;
                Book = await _bookService.GetBookDetailsAsync(id);
                Title = Book?.Info?.Title;
                IsBusy = false;
            }
        }
    }
}

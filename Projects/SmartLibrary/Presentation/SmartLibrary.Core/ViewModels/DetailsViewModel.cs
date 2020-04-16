using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using SmartLibrary.Core.Events;
using SmartLibrary.Core.Interfaces;
using SmartLibrary.Core.Models;
using SmartLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Essentials;

namespace SmartLibrary.Core.ViewModels
{
    public class DetailsViewModel : ViewModelBase
    {
        private readonly IBookService _bookService;
        private readonly IBookShareClient _bookShareClient;
        private readonly ILocationService _locationService;
        private readonly IUserService _userService;

        public DetailsViewModel(INavigationService navigationService, IBookService bookService, IBookShareClient bookShareClient, IEventAggregator eventAggregator, ILocationService locationService, IUserService userService) : base(navigationService)
        {
            this._bookService = bookService;
            this._bookShareClient = bookShareClient;
            this._locationService = locationService;
            this._userService = userService;
            eventAggregator.GetEvent<BookSharedEvent>().Subscribe(b => Title = b.BookId);
        }

        public Book Book { get; set; }
        public ICommand SaveCommand => new DelegateCommand(DoSave);

        private async void DoSave()
        {
            var location = await _locationService.GetLocationQuick();
            string notes = "Notizen";
            SavedBook savedBook = new SavedBook
            {
                BookId = Book?.Id,
                SaveDate = DateTimeOffset.Now,
                UserName = _userService.IsLoggedIn ? _userService.UserName : "somebody",
                Notes = notes,
                Location = location
            };
            await _bookShareClient.ShareBook(savedBook);
        }

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

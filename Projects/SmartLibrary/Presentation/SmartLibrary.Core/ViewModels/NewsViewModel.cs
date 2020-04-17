using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using SmartLibrary.Core.Interfaces;
using SmartLibrary.Core.Models;
using SmartLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SmartLibrary.Core.ViewModels
{
    public class NewsViewModel : ViewModelBase
    {
        private readonly IBookStorage _storage;

        public NewsViewModel(INavigationService navigationService, IEventAggregator eventAggregator, IBookStorage storage) : base(navigationService, eventAggregator)
        {
            Title = "Shared Pages";
            this._storage = storage;
        }

        public ICollection<SavedBookEntry> SharedBooks { get; private set; }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            IsBusy = true;
            SharedBooks = new ObservableCollection<SavedBookEntry>(await _storage.GetSharedBooks());
            IsBusy = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace HelloCross.Core.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel
    {
		public BaseViewModel(IMvxNavigationService navigationService)
		{
			NavigationService = navigationService;
		}

		private string _title;

		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}

		protected IMvxNavigationService NavigationService { get; }
	}
}

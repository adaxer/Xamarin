using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace HelloCross.Core.ViewModels
{
	public class BaseViewModel : BaseViewModel<object>
	{
		public BaseViewModel(IMvxNavigationService navigationService) : base(navigationService)
		{
		}

		public override void Prepare(object parameter)
		{
		}
	}

	public abstract class BaseViewModel<T> : MvxViewModel<T>
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

		public bool IsBusy { get; set; }

		protected IMvxNavigationService NavigationService { get; }
	}
}

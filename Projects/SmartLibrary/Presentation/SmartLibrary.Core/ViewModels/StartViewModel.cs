using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartLibrary.Core.ViewModels
{
    public class StartViewModel : ViewModelBase
    {
        public StartViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}

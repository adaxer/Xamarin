﻿using HelloCross.Core.ViewModels;
using MvvmCross.Platforms.Uap.Presenters.Attributes;
using MvvmCross.Platforms.Uap.Views;
using MvvmCross.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HelloCross.UWP.Views
{
    [MvxPagePresentation]
    [MvxViewFor(typeof(ResearchViewModel))]
    public sealed partial class ResearchPage : MvxWindowsPage
    {
        public ResearchPage()
        {
            this.InitializeComponent();
        }
    }
}

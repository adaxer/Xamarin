using MvvmCross.Platforms.Uap.Presenters.Attributes;
using MvvmCross.Platforms.Uap.Views;
using MvvmCross.ViewModels;
using HelloCross.Core.ViewModels;

namespace HelloCross.UWP
{
    [MvxPagePresentation]
    [MvxViewFor(typeof(MainViewModel))]
    public sealed partial class MainPage : MvxWindowsPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
}

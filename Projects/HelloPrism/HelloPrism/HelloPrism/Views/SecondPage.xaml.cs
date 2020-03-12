using HelloPrism.ViewModels;
using Xamarin.Forms;

namespace HelloPrism.Views
{
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            if(BindingContext is IGuardBackNavigation guard)
            {
                return !guard.CanGoBack;
            }
            return base.OnBackButtonPressed();
        }
    }
}

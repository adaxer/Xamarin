using Xamarin.Forms;

namespace SmartLibrary.Core.Views
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();

            NavigationPage.SetHasBackButton(this, false);
        }
    }
}

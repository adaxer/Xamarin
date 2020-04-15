using Hello;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Unity;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HelloUwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MainViewModel _mainViewModel;

        public MainPage()
        {
            this.InitializeComponent();
            _mainViewModel = (Application.Current as App).Container.Resolve<MainViewModel>();
            DataContext = _mainViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var data = _mainViewModel.GetData();
        }
    }
}

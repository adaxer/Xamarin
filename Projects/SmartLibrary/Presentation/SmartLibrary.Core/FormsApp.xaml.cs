using Prism;
using Prism.Ioc;
using SmartLibrary.Core.Interfaces;
using SmartLibrary.Core.Services;
using SmartLibrary.Core.ViewModels;
using SmartLibrary.Core.Views;
using System.Globalization;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SmartLibrary.Core
{
    public partial class FormsApp
    {
        private BookShareClient _shareClient;

        /* 
* The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
* This imposes a limitation in which the App class must have a default constructor. 
* App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
*/
        public FormsApp() : this(null) { }

        public FormsApp(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("/StartPage/NavigationPage/WelcomePage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IRestService, RestService>();
            containerRegistry.Register<IBookService, BookService>();
            containerRegistry.Register<ISettingsService, XamarinPreferences>();
            containerRegistry.Register<ILocationService, LocationService>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<StartPage, StartViewModel>();
            containerRegistry.RegisterForNavigation<WelcomePage, WelcomeViewModel>();
            containerRegistry.RegisterForNavigation<SearchPage, SearchViewModel>();
            containerRegistry.RegisterForNavigation<DetailsPage, DetailsViewModel>();

            containerRegistry.RegisterInstance<IUserService>(Container.Resolve<UserService>());
            InitializeShareClient(containerRegistry);
        }

        private void InitializeShareClient(IContainerRegistry containerRegistry)
        {
            _shareClient = Container.Resolve<BookShareClient>();
            containerRegistry.RegisterInstance<IBookShareClient>(_shareClient);
            _shareClient.Initialize();
        }
    }
}

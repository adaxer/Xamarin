using System;
using Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloForms
{
    public partial class App : Application
    {
        private UnityContainer _container;

        public App(Action<IUnityContainer> platformBootstrap)
        {
            InitializeComponent();
            Bootstrap();
            platformBootstrap(_container);
            (_container.Resolve<INavigationService>() as NavigationService).Start("Main");
        }

        private void Bootstrap()
        {
            _container = new UnityContainer();
            _container.RegisterInstance<INavigationService>(new NavigationService(_container));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

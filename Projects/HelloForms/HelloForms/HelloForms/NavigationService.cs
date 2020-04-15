using System;
using System.Threading.Tasks;
using Unity;
using Xamarin.Forms;

namespace HelloForms
{
    public class NavigationService : INavigationService
    {
        private readonly IUnityContainer _container;
        private string _namespace;
        internal NavigationPage _navigationPage;

        public NavigationService(IUnityContainer container)
        {
            _container = container;
            _namespace = GetType().FullName.Replace("NavigationService", "");
        }

        internal void Start(string pageName)
        {
            Type pageType = Type.GetType($"{_namespace}{pageName}Page");
            Type vmType = Type.GetType($"{_namespace}{pageName}ViewModel");
            Page page = Activator.CreateInstance(pageType) as Page;
            page.BindingContext = _container.Resolve(vmType);
            Application.Current.MainPage = _navigationPage = new NavigationPage(page);
        }

        public Task Navigate(string destination)
        {
            Type pageType = Type.GetType($"{_namespace}{destination}Page");
            Type vmType = Type.GetType($"{_namespace}{destination}ViewModel");
            Page page = Activator.CreateInstance(pageType) as Page;
            page.BindingContext = _container.Resolve(vmType);
            return _navigationPage.PushAsync(page);
        }
    }
}
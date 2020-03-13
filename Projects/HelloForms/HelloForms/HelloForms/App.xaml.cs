using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloForms
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            MainPage.BindingContext = new MainViewModel();
            SetBindings(MainPage);
            // MainPage.BindingContext = new Button();
        }

        // Mini Mvvm-Framework f. DataBinding
        private void SetBindings(Page mainPage)
        {
            //string xaml = "<Label lib:Bind=\"Text Title\" />";
            //// Parse =>
            //string binding = "Text Title";
            //Label l;
            //l.PropertyChanged += (s,e) => if(e.PropertyName=="Text") l.BindingContext.GetType().InvokeMember("Title", System.Reflection.BindingFlags.SetProperty, null, l.BindingContext, new object[] { l.Text});
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

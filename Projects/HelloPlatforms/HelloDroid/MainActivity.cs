using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Hello;
using System;
using Unity;
using Common;

namespace HelloDroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        MainViewModel _mainViewModel;
        private Button _theButton;
        private UnityContainer _container;
        internal IUnityContainer Container => _container;

        public MainActivity()
        {
            Bootstrap();
        }

        private void Bootstrap()
        {
            _container = new UnityContainer();
            _container.RegisterType<IDataService, DataService>();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            _mainViewModel = Container.Resolve<MainViewModel>();
            _theButton = FindViewById<Button>(Resource.Id.button1);
            _theButton.Click += OnClick;
        }

        private void OnClick(object sender, System.EventArgs e)
        {
            var data = _mainViewModel.GetData();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
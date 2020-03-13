
using Android.App;
using Android.OS;
using HelloCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace HelloCross.Droid.Views
{
    [Activity(Label="Queries")]
    public class QueriesView : MvxAppCompatActivity<QueriesViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.QueriesView);
            //ProgressBar pb;
            //EditText et;
            //et.TextChanged += (s,e) => viewmodel.Title = et.Text
        }
    }
}
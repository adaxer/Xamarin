using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HelloCross.Core.ViewModels;
using MvvmCross.Platforms.Android.Views;

namespace HelloCross.Droid.Views
{
    [Activity(Label="Research")]
    public class ResearchView : MvxActivity<ResearchViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ResearchView);
        }
    }
}
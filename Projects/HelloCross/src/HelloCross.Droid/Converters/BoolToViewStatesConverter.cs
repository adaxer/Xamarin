using Android.Views;
using MvvmCross.Converters;
using System;
using System.Globalization;

namespace HelloCross.Droid.Converters
{
    public class BoolToViewStatesConverter : MvxValueConverter<bool, ViewStates>
    {
        protected override ViewStates Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            return value
                ? ViewStates.Visible
                : ViewStates.Gone;
        }
    }
}
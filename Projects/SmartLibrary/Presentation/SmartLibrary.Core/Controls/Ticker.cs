using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SmartLibrary.Core.Controls
{
    public class Ticker : ContentView
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(Ticker), "-", propertyChanged: TextChanged);

        private static void TextChanged(BindableObject bindable, object oldValue, object newValue)
        {
        }

        public static readonly BindableProperty SecondsActiveProperty = BindableProperty.Create(nameof(SecondsActive), typeof(int), typeof(Ticker), 1);
        // ...

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public int SecondsActive
        {
            get => (int)GetValue(SecondsActiveProperty);
            set => SetValue(SecondsActiveProperty, value);
        }
        // ...
    }
}

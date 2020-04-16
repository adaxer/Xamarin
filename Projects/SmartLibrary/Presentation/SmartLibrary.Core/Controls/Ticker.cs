using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SmartLibrary.Core.Controls
{
    public class Ticker : Label
    {
        public static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(Content), typeof(string), typeof(Ticker), "-", propertyChanged: ContentChanged);

        private static void ContentChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as Ticker).Animate();
        }

        public Ticker()
        {
            IsVisible = false;
        }

        private async void Animate()
        {
            Text = Content;
            if (string.IsNullOrEmpty(Text))
            {
                return;
            }
            ViewExtensions.CancelAnimations(this);
            var parent = this.Parent as VisualElement ?? this;
            var start = DateTimeOffset.Now;
            IsVisible = true;
            bool isCancelled = false;
            while ((DateTimeOffset.Now - start).TotalSeconds < SecondsActive && !isCancelled)
            {
                // Animations: https://github.com/xamarin/xamarin-forms-samples/releases/download/113531/Xamarin_Forms___Basic_Animation.zip
                isCancelled = await this.TranslateTo(parent.Width, 0, 0);
                isCancelled = await this.TranslateTo(-Width, 0, 15000);
            }
            IsVisible = false;
        }

        public static readonly BindableProperty SecondsActiveProperty = BindableProperty.Create(nameof(SecondsActive), typeof(int), typeof(Ticker), 1);
        // ...

        public string Content
        {
            get => (string)GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        public int SecondsActive
        {
            get => (int)GetValue(SecondsActiveProperty);
            set => SetValue(SecondsActiveProperty, value);
        }
        // ...
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HelloForms
{
    public class MainViewModel : INotifyPropertyChanged
    {
        //public string Title { get; set; } = "Hi there";
        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
            }
        }

        public ICommand GreetCommand
        {
            get
            {
                return new Command(Greet);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //public ICommand get_GreetCommand()
        //{
        //    return new Command(Greet);
        //}

        private void Greet(object obj)
        {
            this.Title = "Hello again";
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
            //Application.Current.MainPage = new SecondPage { BindingContext = new SecondViewMOdel}
            //NavigationService.NavigateTo(nameof(SecondViewModel));
            // Schritte zu eigenem oder fremdem MVVM-Framework
        }
    }
}

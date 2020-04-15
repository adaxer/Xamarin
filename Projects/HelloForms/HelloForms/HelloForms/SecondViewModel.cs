using System;
using System.Threading.Tasks;

namespace HelloForms
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public  class SecondViewModel
    {
        public SecondViewModel(IPlatformInfo platformInfo)
        {
            Title = "Ermittle Plattform...";
            SetPlatform(platformInfo.OSName);
        }

        private async void SetPlatform(string oSName)
        {
            await Task.Delay(2000);
            Title = oSName;
        }

        public string Title { get; set; }
    }
}
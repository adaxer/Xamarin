using SmartLibrary.Core.Interfaces;
using Xamarin.Essentials;

namespace SmartLibrary.Core.Services
{
    public class XamarinPreferences : ISettingsService
    {
        public void ClearAll() => Preferences.Clear();

        public string Get(string key, string defValue=null) => Preferences.Get(key, defValue);

        public void Set(string key, string value) => Preferences.Set(key, value);

        public void Clear(string key) => Preferences.Remove(key);

        public bool Has(string key) => Preferences.ContainsKey(key);
    }
}

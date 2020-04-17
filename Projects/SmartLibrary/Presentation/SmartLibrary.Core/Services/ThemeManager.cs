using Prism.Events;
using SmartLibrary.Core.Events;
using SmartLibrary.Core.Interfaces;
using System;
using System.Linq;
using Xamarin.Forms;

namespace SmartLibrary.Core.Services
{
    public class ThemeManager : IThemeManager
    {
        private IEventAggregator _events;
        Theme _currentTheme;

        public ThemeManager(IEventAggregator events)
        {
            _events = events;
            _currentTheme = Theme.Light;
        }

        public Theme CurrentTheme => _currentTheme;


        public void ChangeTheme(Theme newTheme)
        {
            Func<ResourceDictionary, bool> predi = d => d.GetType().Name.Contains("Themes") || (d.Source != null && d.Source.OriginalString.Contains("Themes"));
            var themeDic = Application.Current.Resources.MergedDictionaries.SingleOrDefault(predi);
            Application.Current.Resources.MergedDictionaries.Remove(themeDic);
            var newDic = Activator.CreateInstance(Type.GetType($"SmartLibrary.Core.Themes.{newTheme}")) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Add(newDic);
            _events.GetEvent<ThemeChangedEvent>().Publish(newTheme);
        }
    }
}

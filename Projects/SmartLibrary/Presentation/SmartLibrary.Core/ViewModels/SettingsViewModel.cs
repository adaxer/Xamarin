using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using SmartLibrary.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace SmartLibrary.Core.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public SettingsViewModel(INavigationService navigationService, IEventAggregator eventAggregator, ISettingsService settingsService, IThemeManager themeManager) : base(navigationService, eventAggregator)
        {
            Title = "Einstellungen";
            this._settingsService = settingsService;
            this._themeManager = themeManager;
            Themes = new List<string> { "Light", "Dark" };
            CurrentTheme =_settingsService.Get("Theme", "Light");
        }

        public ICollection<string> Themes { get; set; }

        private string _currentTheme;
        private readonly ISettingsService _settingsService;
        private readonly IThemeManager _themeManager;

        public string CurrentTheme
        {
            get { return _currentTheme; }
            set 
            { 
                _currentTheme = value;
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _themeManager.ChangeTheme((Theme)Enum.Parse(typeof(Theme), _currentTheme));
                    _settingsService.Set("Theme", CurrentTheme);
                }
            }
        }

    }
}

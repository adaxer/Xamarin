namespace SmartLibrary.Core.Interfaces
{
    public interface IThemeManager
    {
        void ChangeTheme(Theme newTheme);
        Theme CurrentTheme { get; }
    }

    public enum Theme
    {
        Light,
        Dark
    }
}

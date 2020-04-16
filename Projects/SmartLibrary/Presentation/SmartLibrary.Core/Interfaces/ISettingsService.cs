namespace SmartLibrary.Core.Interfaces
{
    public interface ISettingsService
    {
        void ClearAll();

        string Get(string key, string defValue=null);

        void Set(string key, string value);

        void Clear(string key);

        bool Has(string key);
    }
}

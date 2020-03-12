using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Interfaces
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

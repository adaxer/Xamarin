using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Interfaces
{
    public interface ITranslate
    {
        string Get(string key, params string[] args);
    }

}

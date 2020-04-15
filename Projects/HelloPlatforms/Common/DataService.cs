using System;

namespace Common
{
    public interface IDataService
    {
        string LoadData();
    }

    public class DataService : IDataService
    {
        public string LoadData() => "Loaded data";
    }
}

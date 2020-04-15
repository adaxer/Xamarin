

using Common;

namespace Hello
{
    public class MainViewModel
    {
        IDataService _dataService;

        public string Title { get; set; } = "Main ViewModel";

        public MainViewModel(IDataService dataService)
        {
            _dataService =dataService;
        }

        public string GetData()
        {
# if __ANDROID__
            return _dataService.LoadData();
#elif WINDOWS_UWP
            return _dataService.LoadData();
#else
            return _dataService.LoadData();
#endif
        }
    }
}
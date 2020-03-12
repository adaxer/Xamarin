using HelloCross.Core.Interfaces;
using HelloCross.Core.Services;
using HelloCross.Core.ViewModels;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace HelloCross.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.IoCProvider.RegisterType<ISettingsService, XamarinPreferences>();

            RegisterAppStart<MainViewModel>();
        }
    }
}

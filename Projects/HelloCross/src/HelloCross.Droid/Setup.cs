using HelloCross.Core;
using MvvmCross.Logging;
using MvvmCross.Platforms.Android.Core;
using Serilog;
using Serilog.Sinks.SystemConsole;

namespace HelloCross.Droid
{
    public class Setup : MvxAndroidSetup<App>
    {
        protected override IMvxLogProvider CreateLogProvider()
        {
            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Verbose()
                        .WriteTo.AndroidLog()
                        .CreateLogger();
            return base.CreateLogProvider();
        }

        public override MvxLogProviderType GetDefaultLogProviderType()
        {
            return MvxLogProviderType.Serilog;
        }
    }
}
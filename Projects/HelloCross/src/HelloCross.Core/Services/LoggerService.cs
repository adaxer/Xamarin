using HelloCross.Core.Interfaces;
using System.Diagnostics;

namespace HelloCross.Core.Services
{
    public class LoggerService : ILoggerService
    {
        public void Info(string msg)
        {
            Trace.WriteLine(msg);
        }
    }
}

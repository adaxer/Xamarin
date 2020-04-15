using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace HelloForms.iOS
{
    public class IOSInfo:IPlatformInfo
    {
        public string OSName => "IOS";
    }
}
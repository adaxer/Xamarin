using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Text;
using Xamarin.Forms.Xaml;

namespace SmartLibrary.Localization
{
    public class Loc : IMarkupExtension
    {
        private static ResourceManager resourceManager;
        public ResourceManager ResManager
        {
            get
            {
                if (resourceManager == null)
                {
                    resourceManager = new ResourceManager("SmartLibrary.Localization.Strings", GetType().Assembly);
                }

                return resourceManager;
            }
        }

        public string Key { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var result = ResManager.GetString(Key, CultureInfo.CurrentCulture);
            return result;
        }
    }
}

using Books.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Books.Services.i18n
{
    public class Loc : IMarkupExtension
    {
        private static ITranslate _translate;

        public string Key { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            string result = (_translate ?? (_translate = (Application.Current as App).Container.Resolve(typeof(ITranslate)) as ITranslate)).Get(Key);
            return result;
        }
    }

}

using Prism.Events;
using SmartLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLibrary.Core.Events
{
    public class BookSharedEvent : PubSubEvent<SavedBook>
    {
    }
}

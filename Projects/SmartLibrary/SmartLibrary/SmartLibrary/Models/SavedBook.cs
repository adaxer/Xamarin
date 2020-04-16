using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLibrary.Core.Models
{
    public class SavedBook
    {
        public string BookId { get; set; }
        public string UserName { get; set; }
        public DateTimeOffset SaveDate { get; set; }
        public string Notes { get; set; }
    }
}

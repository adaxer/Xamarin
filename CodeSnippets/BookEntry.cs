using Cirrious.MvvmCross.Plugins.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core.Models
{
    public class BookEntry
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string BookId { get; set; }

        public string Title { get; set; }

        public string UserName { get; set; }

        public DateTime Saved { get; set; }
    }
}

using Realms;
using System;

namespace HelloCross.Core.Models
{
    public class BookEntry
    {
        //[PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string BookId { get; set; }

        public string Title { get; set; }

        public string UserName { get; set; }

        public DateTime Saved { get; set; }
    }


    public class BookQueryResult : RealmObject
    {
        public int Count { get; set; }
        public string SearchText { get; set; }
        public DateTimeOffset Date { get; set; }
    }

}

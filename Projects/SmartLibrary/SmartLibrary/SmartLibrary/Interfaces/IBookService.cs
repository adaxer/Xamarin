using SmartLibrary.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartLibrary.Core.Interfaces
{
    public interface IBookService
    {
        Task<BookQuery> BookQueryAsync(string text);

        Task<Book> GetBookDetailsAsync(string id);

        //Task SaveBookAsync(Book book, string notes);

        //Task UploadBookAsync(Book book, string notes);
    }
}

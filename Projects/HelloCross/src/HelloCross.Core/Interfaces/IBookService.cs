using HelloCross.Core.Models;
using System.Threading.Tasks;

namespace HelloCross.Core.Interfaces
{
    public interface IBookService
    {
        Task<BookQuery> BookQueryAsync(string text);

        Task<(Book book, string notes)> GetBookDetailsAsync(string id);

        Task SaveBookAsync(Book book, string notes);

        Task UploadBookAsync(Book book, string notes);
    }
}

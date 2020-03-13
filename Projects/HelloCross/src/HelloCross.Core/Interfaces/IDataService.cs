using HelloCross.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloCross.Core.Interfaces
{
    public interface IDataService
    {
        Task SaveBook(Book book, string notes);
        Task<IEnumerable<BookEntry>> GetEntries();
    }
}
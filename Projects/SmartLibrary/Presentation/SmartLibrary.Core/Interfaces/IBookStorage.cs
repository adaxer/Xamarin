using SmartLibrary.Core.Models;
using SmartLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartLibrary.Core.Interfaces
{
    public interface IBookStorage
    {
        Task<IEnumerable<SavedBookEntry>> GetSharedBooks();
    }
}

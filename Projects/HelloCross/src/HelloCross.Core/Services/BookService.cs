using HelloCross.Core.Interfaces;
using HelloCross.Core.Models;
using Newtonsoft.Json;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloCross.Core.Services
{
    public class BookService : IBookService
    {
        IRestService _rest;
        IDataService _dataService;

        public BookService(IRestService rest, IDataService data)
        {
            _rest = rest;
            _dataService = data;
        }

        public async Task<BookQuery> BookQueryAsync(string text)
        {
            var result = await _rest.GetDataAsync<BookQuery>
                (string.Format("https://www.googleapis.com/books/v1/volumes?q={0}&maxResults=40", text));

            string json = JsonConvert.SerializeObject(result.Books);
            return result;

        }

        public async Task<(Book book, string notes)> GetBookDetailsAsync(string id)
        {
            var entry = (await _dataService.GetEntries()).FirstOrDefault(e => e.BookId == id);
            string notes = entry == null
                ? string.Empty
                : entry.BookId;

            Book book = await _rest.GetDataAsync<Book>(string.Format("https://www.googleapis.com/books/v1/volumes/{0}", id));

            return (book, notes);
        }

        public async Task<IEnumerable<BookQueryResult>> GetQueriesAsync()
        {
            var realm = await Realm.GetInstanceAsync();
            var savedQueries = realm.All<BookQueryResult>();
            return savedQueries;
        }

        public async Task SaveBookAsync(Book book, string notes)
        {
            await _dataService.SaveBook(book, notes);
        }

        public async Task SaveQueryAsync(BookQueryResult bookQueryResult)
        {
            var realm = await Realm.GetInstanceAsync();
            await realm.WriteAsync(r =>
            {
                r.Add<BookQueryResult>(bookQueryResult);
            });
        }

        public Task UploadBookAsync(Book book, string notes)
        {
            throw new NotImplementedException();
        }
    }
}

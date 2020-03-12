using Books.Events;
using Books.Interfaces;
using Books.Models;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Books.Services
{
    public class ShareBooks : IShareBooks
    {
        private HubConnection _connection;
        private IEventAggregator _events;

        public ShareBooks(IEventAggregator events)
        {
            _events = events;
            Initialize();
        }

        private async void Initialize()
        {
            _connection = new HubConnectionBuilder()
                .WithUrl("https://daxbookserver.azurewebsites.net/messagehub")
                //.WithUrl("http://localhost:5000/messagehub")
                .Build();

           _connection.On<string>("BookShared", RaiseBookShared);

            try
            {
                await _connection.StartAsync();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
            }
        }

        private void RaiseBookShared(string bookInfo)
        {
            _events.GetEvent<BookSharedEvent>().Publish(JsonConvert.DeserializeObject<Book>(bookInfo));
        }

        public async Task ShareBook(Book book)
        {
            try
            {
                await _connection.InvokeAsync("ShareBook", JsonConvert.SerializeObject(book));
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
            }
        }
    }
}

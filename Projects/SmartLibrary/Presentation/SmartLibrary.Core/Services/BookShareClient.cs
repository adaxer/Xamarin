using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using Prism.Events;
using SmartLibrary.Core.Events;
using SmartLibrary.Core.Interfaces;
using SmartLibrary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace SmartLibrary.Core.Services
{
    public class BookShareClient : IBookShareClient
    {
        private HubConnection _connection;
        private IEventAggregator _events;

        public BookShareClient(IEventAggregator events)
        {
            _events = events;
        }

        public async Task Initialize()
        {
            try
            {
                _connection = new HubConnectionBuilder()
                    .WithUrl($"{AppSettingsManager.Settings["ApiBaseUrl"]}bookshub")
                    .Build();

                _connection.On<string>("BookShared", OnBookShared);
                await _connection.StartAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        private void OnBookShared(string json)
        {
            var book = JsonConvert.DeserializeObject<SavedBook>(json);
            _events.GetEvent<BookSharedEvent>().Publish(book);
        }

        public async Task<bool> ShareBook(SavedBook book)
        {
            try
            {
                if(_connection.State == HubConnectionState.Disconnected)
                {
                    await Initialize();
                }
                await _connection.InvokeAsync("ShareBook", JsonConvert.SerializeObject(book));
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }
    }
}

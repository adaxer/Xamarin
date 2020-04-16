using SmartLibrary.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace SmartLibrary.Core.Services
{
    public class LocationService : ILocationService
    {
        public async Task<SmartLibrary.Models.Location> GetLocationQuick()
        {
            var result = await  Geolocation.GetLastKnownLocationAsync();
            return new SmartLibrary.Models.Location { Longitude = result.Longitude, Latitude = result.Latitude };
        }
    }
}

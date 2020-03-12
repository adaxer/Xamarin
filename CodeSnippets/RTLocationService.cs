using Position.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace Position.UWP
{
    public class RTLocationService : ILocationService
    {
        private Geolocator m_Locator;

        public RTLocationService()
        {
            m_Locator = new Geolocator();
        }
        public event Action<double, double> LocationUpdated;

        public async void MeasureLocation()
        {
            double lat = -1.0, lng = -1.0;
            try
            {
                //await Task.Delay(100);
                Geoposition pos = await m_Locator.GetGeopositionAsync();
                lat = pos.Coordinate.Point.Position.Latitude;
                lng = pos.Coordinate.Point.Position.Longitude;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

            }
            finally
            {
                if (LocationUpdated != null)
                    LocationUpdated(lat, lng);
            }
        }
    }
}

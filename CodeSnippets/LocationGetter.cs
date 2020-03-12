using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Locations;
using Position.Core;
using System.Threading.Tasks;

namespace Position.Droid
{
    public class LocationGetter : Java.Lang.Object, ILocationListener, ILocationService
    {
        private LocationManager m_LocationManager;
        private string m_LocationProvider;

        public LocationGetter(Activity act, string locationService)
        {
            m_LocationManager = (LocationManager) act.GetSystemService(locationService);
            Criteria criteriaForLocationService = new Criteria
            {
                Accuracy = Accuracy.Fine
            };
            m_LocationProvider = m_LocationManager.GetBestProvider(criteriaForLocationService, true);
            m_LocationManager.RequestLocationUpdates(m_LocationProvider, 0, 0, this);
        }

        public event Action<double, double> LocationUpdated;

        public async void MeasureLocation()
        {
            await Task.Delay(1000);
            var loc = m_LocationManager.GetLastKnownLocation(m_LocationProvider);
            OnLocationChanged(loc);
        }

        public void OnLocationChanged(Location location)
        {
            if (LocationUpdated != null)
                LocationUpdated(location.Latitude, location.Longitude);
        }

        public void OnProviderDisabled(string provider)
        {
            System.Diagnostics.Debug.WriteLine($"{provider} disabled");
        }

        public void OnProviderEnabled(string provider)
        {
            System.Diagnostics.Debug.WriteLine($"{provider} enabled");
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            System.Diagnostics.Debug.WriteLine($"{provider}: {status}");
        }
    }
}
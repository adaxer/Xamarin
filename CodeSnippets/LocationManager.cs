using CoreLocation;
using Position.Core;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace Position.IOS
{
    public class LocationManager : ILocationService
    {
        protected CLLocationManager locMgr;

        public LocationManager()
        {
            this.locMgr = new CLLocationManager();
            this.locMgr.PausesLocationUpdatesAutomatically = false;

            // iOS 8 has additional permissions requirements
            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                locMgr.RequestAlwaysAuthorization(); // works in background
                                                     //locMgr.RequestWhenInUseAuthorization (); // only in foreground
            }

            if (UIDevice.CurrentDevice.CheckSystemVersion(9, 0))
            {
                locMgr.AllowsBackgroundLocationUpdates = true;
            }
        }

        public event Action<double, double> LocationUpdated;

        public CLLocationManager LocMgr
        {
            get { return this.locMgr; }
        }

        public void MeasureLocation()
        {
            if (CLLocationManager.LocationServicesEnabled)
            {
                //set the desired accuracy, in meters
                LocMgr.DesiredAccuracy = 1;
                LocMgr.LocationsUpdated += (object sender, CLLocationsUpdatedEventArgs e) =>
                {
                    var coord = e.Locations[e.Locations.Length - 1].Coordinate;
                    // fire our custom Location Updated event
                    if(LocationUpdated !=null)
                        LocationUpdated(coord.Latitude, coord.Longitude);
                };
                LocMgr.StartUpdatingLocation();
            }
        }
    }
}

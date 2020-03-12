using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Position.Core
{
    public interface ILocationService
    {
        event Action<double,double> LocationUpdated;
        void MeasureLocation();
    }
}

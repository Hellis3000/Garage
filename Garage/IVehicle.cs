using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public interface IVehicle
    {
        string Model { get; set; }
        string Manufacturer { get; set; }
        string VehicleType { get; set; }
        string RegNo { get; set; }
        string Color { get; set; }

        // You can add more methods or properties common to all vehicles here
    }

}

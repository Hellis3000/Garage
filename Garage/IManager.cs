using Garage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageMaker
{
    public interface IManager
    {
        int inputCap { get; set; }
        void Run();
        void GetGarageSize();
        void SetGarage();
        void searchVehicles();
        bool CheckParking();
        void Park();

    }
}
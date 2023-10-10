using Garage;
using GarageMaker;

public interface IHandler
{

    void CheckParking(IVehicle vehicle);
    List<string> ListAllVehiclesInGarage();
    void AddVehicle(IVehicle vehicle);

    string GetVehicleInfo(IVehicle vehicle);

    List<string> SearchAndListVehicles(List<string> searchTerms);
    int GetFilledSpots();
   

}


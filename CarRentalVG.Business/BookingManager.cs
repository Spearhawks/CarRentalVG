using CarRentalVG.Common;
using CarRentalVG.Common.Classes;
using CarRentalVG.Common.Enums;
using CarRentalVG.Common.Interfaces;
using CarRentalVG.Data.Interfaces;

namespace CarRentalVG.Business;

public class BookingManager
{
    private readonly IData _db;
    public BookingManager(IData db) => _db = db;

    /// <summary>
    ///  Fixa dessa 6 metoder.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<IBooking> GetBookings() { return null; }
    public IEnumerable<Customer> GetCustomers() { return null; }
    public IPerson? GetPerson(string ssn) { return null; }
    public IEnumerable<IVehicle> GetVehicles(RentedStatus status = default) { return null; }
    public IVehicle? GetVehicle(int vehicleId) { return null; }
    public IVehicle? GetVehicle(string regNo) { return null; }

    public async Task<IBooking> RentVehicle(int vehicleID, int customerId)
    {
        return null;
    }
    public IBooking ReturnVehicle(int vehicleID, double distance)
    {
        return null;
    }
    public void AddVehicle(string make, string regNo, double odometer, double costKm, RentedStatus status, VehicleTypes type)
    {

    }
    public void AddCustomers(string ssn, string firstName, string lastName)
    {

    }
    public string[] VehicleStatusNames => _db.RentedStatusNames;
    public string[] VehicleTypeNames => _db.VehicleTypeNames;
    public VehicleTypes GetVehicleType(string name) => _db.GetVehicleType(name);
}


/*
 

Att göra:

Interface:
    - Skapa inputs och dropdowns och knappar m.m.
    - Justera tabellplacering.


Datalagret:
    - Skapa generiska metoder i Data.
    - Skapa och läs in JSON-filer.
    - Läs på om expresions och reflection-metoder.
    - Här ska metoder för att hyra och lämna tillbaka finnas.
    - Metoder för att lägga till Id+1 i listorna.

Common:
    - Car och Motrocycle ska ärva från Vehicle.
    - Läs på om arv.
    - Id på alla listor.

Business:
    - RentVehicle metoden ska vara asynkron och låsa alla knappar i typ 10 sekunder.









 
 */
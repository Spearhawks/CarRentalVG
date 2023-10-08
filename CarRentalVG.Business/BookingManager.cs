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

    #region Index.razor code

    public int? _ssn;
    public string _firstName;
    public string _lastName;
    public int? _kmreturned;

    #endregion

    /// <summary>
    ///  Fixa dessa 6 metoder.
    /// </summary>
    /// <returns></returns>
    // public IEnumerable<IBooking> GetBookings() { return null; }
    //public IEnumerable<Customer> GetCustomers() { return null; }
    public IPerson? GetPerson(string ssn) { return null; }
    public IEnumerable<IVehicle> GetVehicles(RentedStatus status = default) { return null; }
    public IVehicle? GetVehicle(int vehicleId) { return null; }
    public IVehicle? GetVehicle(string regNo) { return null; }

    public async Task<IBooking> RentVehicle(int vehicleId, int customerId)
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
    public void AddCustomers(int ssn, string firstName, string lastName)
    {
        var c = new Customer(ssn, firstName, lastName);
        _db.AddPers(c);
    }
    public string[] VehicleStatusNames => _db.RentedStatusNames;
    public string[] VehicleTypeNames => _db.VehicleTypeNames;
    public VehicleTypes GetVehicleType(string name) => _db.GetVehicleType(name);

    /// <summary>
    /// Metoder som inte ska användas i slutprodukten.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Customer> GetCustomers() => _db.GetPersons().OfType<Customer>();
    public IEnumerable<IVehicle> GetVehicles() => _db.GetVehicles();
    public IEnumerable<IBooking> GetBookings() => _db.GetBookings();
}


/*
 

Att göra:


Datalagret:
    - Skapa generiska metoder i Data.
    - Läs på om expresions och reflection-metoder.
    - Här ska metoder för att hyra och lämna tillbaka finnas.
    - Använd metoderna för att lägga till Id+1 i listorna.
    - Just nu så är det inga generiska metoder för Get eller Add.

Common:
    - Car och Motrocycle ska ärva från Vehicle.
    - Läs på om arv.
    - Id på alla listor.

Business:
    - RentVehicle metoden ska vara asynkron och låsa alla knappar i typ 10 sekunder.
    - RentVehicle tar data från customer och vehicle och lägger ihop till en bokning.

Index:
    - När rent-klickas så ta och hämta id på vehicle och customer och skicka in dem i RentVehicle.









 
 */
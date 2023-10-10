using CarRentalVG.Common;
using CarRentalVG.Common.Classes;
using CarRentalVG.Common.Enums;
using CarRentalVG.Common.Extensions;
using CarRentalVG.Common.Interfaces;
using CarRentalVG.Data.Interfaces;
using System.Runtime.CompilerServices;

namespace CarRentalVG.Business;

public class BookingManager
{
    private readonly IData _db;
    public BookingManager(IData db) => _db = db;

    #region Index.razor code and variables.

    public int? _ssn;
    public string _firstName = string.Empty;
    public string _lastName = string.Empty;
    public int? _kmreturned;
    public bool delayed = false;
    public string _regno = string.Empty;
    public string _make = string.Empty;
    public int? _odom;
    public double? _costkm;
    public int? _costday;
    public VehicleTypes _vehicletype;
    public RentedStatus _rentedStatus;
    public string error = string.Empty;

    #endregion

    #region Metoder som ska anropa generiska metoder i Data.

    // public IEnumerable<IBooking> GetBookings() { return null; }
    // public IEnumerable<Customer> GetCustomers() { return null; }
    //public IPerson? GetPerson(string ssn) { return null; }
    //public IEnumerable<IVehicle> GetVehicles(RentedStatus status = default) { return null; }
    //public IVehicle? GetVehicle(int vehicleId) { return null; }
    //public IVehicle? GetVehicle(string regNo) { return null; }

    #endregion

    #region Metoder för att hyra, returnera och addera fordon och kunder.
    public async Task<IBooking> RentVehicle(int vehicleId, int customerId)
    {
        Task.Delay(10000).Wait(); // Kolla upp mer hur denna ska användas.
        // Addera mha Add<T> metoden till Bookings. Skapa ett Booking-objekt och skicka det till metoden.
        return null;
    }
    public IBooking ReturnVehicle(int vehicleID, double distance)
    {
        // Här används extensionklassen VehicleExtensions metod Duration för att beräkna tiden fordonet varit uthyrt.
        // Ta uthyrningsdatumet samt dagens datum. Skicka in dessa i duration och sätt sen värdet på Cost på bookningen med aktuellt bookingID.
        // Sätt rätt status på fordonet i listan med fordon.
        // 

        return null;
    }
    public void AddVehicle(string make, string regNo, int odometer, double costKm, RentedStatus status, VehicleTypes type)
    {
        // Skapa ett fordon beroende på type, skicka den till Add<T>
        switch(type)
        {
            case VehicleTypes.Motorcycle:
                _db.Add<Vehicle>(new Motorcycle(_db.NextVehicleId, regNo, make, odometer, costKm, (int)_costday, status, type));
                break;
            default:
                _db.Add<Vehicle>(new Car(_db.NextVehicleId, regNo, make, odometer, costKm, (int)_costday, status, type));
                break;
        }
    }
    // Gör om denna så den skapar via Add<T> istället.
    public void AddCustomers(int ssn, string firstName, string lastName)
    {
        if (ssn != 0 && firstName != null && lastName != null)
        {
            // Göra en kontroll om SSN finns redan också?
          //  _db.AddPers(new Customer(ssn, firstName, lastName));

            _db.Add<Customer>(new Customer(ssn, firstName, lastName));
            error = string.Empty;
        }
        else
            error = "Nåt gick fel försök igen.";


            
    }

    #endregion

    #region Tillfällig och ev. onödig kod.

    /// <summary>
    /// Metoder som inte ska användas i slutprodukten.
    /// Ta bort eller ändra dem så de anropar de generiska metoderna.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Customer> GetCustomers() => _db.GetPersons().OfType<Customer>();
    public IEnumerable<IVehicle> GetVehicles() => _db.GetVehicles();
    public IEnumerable<IBooking> GetBookings() => _db.GetBookings();


    // Behövs dessa 3?
    //public string[] VehicleStatusNames => _db.RentedStatusNames;
    //public string[] VehicleTypeNames => _db.VehicleTypeNames;
    //public VehicleTypes GetVehicleType(string name) => _db.GetVehicleType(name);

    #endregion
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

Business:
    - RentVehicle metoden ska vara asynkron och låsa alla knappar i typ 10 sekunder.
    - RentVehicle tar data från customer och vehicle och lägger ihop till en bokning.

Index:
    - När rent-klickas så ta och hämta id på vehicle och customer och skicka in dem i RentVehicle.
    - När add-button klickas så ska fälten rensas.
    - Kontrollera så att ssn eller regno inte redan finns.
    - Skapa egen exception för att hantera fel.
 
 */
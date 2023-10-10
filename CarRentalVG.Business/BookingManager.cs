using CarRentalVG.Common.Classes;
using CarRentalVG.Common.Enums;
using CarRentalVG.Common.Extensions;
using CarRentalVG.Common.Interfaces;
using CarRentalVG.Data.Interfaces;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace CarRentalVG.Business;

public class BookingManager
{
    #region Class construtor and variables

    private readonly IData _db;
    public BookingManager(IData db) => _db = db;
    private int duration = 0;
    
    #endregion

    #region Index.razor code and variables.

    public int? _ssn = 0;
    public string _firstName = string.Empty;
    public string _lastName = string.Empty;
    public int? _kmreturned;
    public bool delayed = false;
    public string _regno = string.Empty;
    public string _make = string.Empty;
    public int _odom;
    public double _costkm;
    public int _costday;
    public VehicleTypes _vehicletype;
    public RentedStatus _rentedStatus;
    public string error = string.Empty;
    public static DateOnly startDate = new DateOnly();
    public static DateOnly endDate = new DateOnly();
    public bool _waitForFinish = false;

    #endregion

    #region Methods used for fetching data in the datalayer.

    // public IEnumerable<IBooking> GetBookings() { return null; }
    // public IEnumerable<Customer> GetCustomers() { return null; }
    // public IPerson? GetPerson(string ssn) { return null; }
    // public IVehicle? GetVehicle(int vehicleId) { return null; }
    // public IVehicle? GetVehicle(string regNo) { return null; }
    // public IVehicle? GetVehicle(int vehicleId){ return null;}

    // Denna verkar fungera nu iaf för att fylla listan i index.
    // Kolla upp expression m.m.
    public IEnumerable<IVehicle> GetVehicles(RentedStatus status = default)
    {
        Expression<Func<IVehicle, bool>> expression = vehicle => vehicle.RentedStatus == status;
        return _db.Get(expression).ToList();
    }    

#endregion

#region Methods for renting and returning vehicles.
public async Task<IBooking> RentVehicle(int vehicleId, int customerId)
    {
        _waitForFinish = true;
        await Task.Delay(5000);

        // Addera mha Add<T> metoden till Bookings. Skapa ett Booking-objekt och skicka det till metoden.
        
        
        _waitForFinish = false;
        return null;    // Returnera bookningen
    }
    public IBooking ReturnVehicle(int vehicleID, double distance)
    {
        duration = VehicleExtensions.Duration(startDate, endDate);


        // Sök fram fordonet, ta ut data för att beräkna cost.
        // Här används extensionklassen VehicleExtensions metod Duration för att beräkna tiden fordonet varit uthyrt.
        // Ta uthyrningsdatumet samt dagens datum och sätt dessa till startDate och endDate.
        // Skicka sen dessa i duration och sätt sen värdet på Cost på bookningen med aktuellt bookingID.
        // Sätt rätt status på fordonet i listan med fordon.


        return null;
    }

    #endregion

    #region Methods for adding vehicles and customers.
    public void AddVehicle(string make, string regNo, int odometer, double costKm, RentedStatus status, VehicleTypes type)
    {
        if (make == string.Empty || regNo == string.Empty || odometer == 0 || costKm == 0 || _costday == 0 || status != RentedStatus.Available)
        {
            error = "Nåt gick fel försök igen.";
        }
        else
        {
            error = string.Empty;
            switch (type)
            {
                case VehicleTypes.Motorcycle:
                    _db.Add<Vehicle>(new Motorcycle(_db.NextVehicleId, regNo, make, odometer, costKm, (int)_costday, status, type));
                    break;
                default:
                    _db.Add<Vehicle>(new Car(_db.NextVehicleId, regNo, make, odometer, costKm, (int)_costday, status, type));
                    break;
            }
        }
    }
    public void AddCustomers(int ssn, string firstName, string lastName)
    {
        if (ssn != 0 && !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
        {
            _db.Add(new Customer(ssn, firstName, lastName));
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
 //   public IEnumerable<IVehicle> GetVehicles() => _db.GetVehicles();
    public IEnumerable<IBooking> GetBookings() => _db.GetBookings();


    // Behövs dessa?
    //public string[] VehicleStatusNames => _db.RentedStatusNames;
    //public string[] VehicleTypeNames => _db.VehicleTypeNames;
    public VehicleTypes GetVehicleType(string name) => _db.GetVehicleType(name);

    #endregion
}


/*
 

Att göra:


Datalagret:
    - Fixa de generiska metoderna i Data.
    - Läs på om expresions och reflection-metoder.
    - Just nu så är det inga generiska metoder för Get.

Common:
    - Får inte riktigt arv att fungera från Vehicle.
    - Behöver jag ha en konstruktor i derive-klassen?

Business:
    - RentVehicle ska ta data från customer och vehicle och lägger ihop till en bokning.

Index:
    - När rent-klickas så ta och hämta id på vehicle och customer och skicka in dem i RentVehicle.
    - När add-button klickas så ska fälten rensas.
 
 */
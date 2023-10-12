﻿using CarRentalVG.Common.Classes;
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
    private int duration = 0; // Använd extensionmetoden i returnmetoden.
    
    #endregion

    #region Index.razor code and variables.

    public int? _ssn = 0;
    public string _firstName = string.Empty;
    public string _lastName = string.Empty;
    public int? _kmreturned;
    public string _regno = string.Empty;
    public string _make = string.Empty;
    public int _odom;
    public double _costkm;
    public int _costday;
    public VehicleTypes _vehicletype;
    public RentedStatus _rentedStatus;
    public string error = string.Empty;
    public static DateOnly startDate = new();
    public static DateOnly endDate = new();
    public bool _waitForFinish = false;
    public int _customerId;

    private void SetDefaultValues()
    {
        _ssn = 0;
        _firstName = string.Empty;
        _lastName = string.Empty;
        _kmreturned = 0;
        _regno = string.Empty;
        _make = string.Empty;
        _odom = 0;
        _costkm = 0;
        _costday = 0;
    }

#endregion

    #region Methods used for fetching data in the datalayer.

// public IEnumerable<IBooking> GetBookings() { return null; }
// public IEnumerable<Customer> GetCustomers() { return null; }

// public IPerson? GetPerson(string ssn) { return null; }
// public IVehicle? GetVehicle(int vehicleId) { return null; }
// public IVehicle? GetVehicle(string regNo) { return null; }
// public IVehicle? GetVehicle(int vehicleId){ return null; }

public string[] VehicleStatusNames => _db.RentedStatusNames;
    public string[] VehicleTypeNames => _db.VehicleTypeNames;
    public VehicleTypes GetVehicleType(string name) => _db.GetVehicleType(name);

    public IEnumerable<Vehicle> GetVehicles(RentedStatus status = default)
    {
        Expression<Func<Vehicle, bool>> expression = vehicle => vehicle.RentedStatus == status;
        return _db.Get(expression);
    }
    public IEnumerable<Customer> GetCustomers()
    {
        Expression<Func<Customer, bool>> expression = customer => customer.Equals(this);
        return _db.Get(expression);
    }
    public IEnumerable<IBooking> GetBookings()
    { 
        Expression<Func<Booking, bool>> expression = booking => booking.Equals(this);
        return _db.Get(expression);
    }

    #endregion

    #region Methods for renting and returning vehicles.
    public async Task<IBooking> RentVehicle(int vehicleId, int customerId)
    {
        if(customerId != 0 &&  vehicleId != 0) 
        { 
            _waitForFinish = true;
            await Task.Delay(5000);

        // Hämtar vehicle och customer på id:et.
        var c = GetCustomers().Single(x => x.Id == customerId);
        var v = GetVehicles().Single(x => x.Id == vehicleId);

        if(v.RentedStatus.Equals(RentedStatus.Available))
        {
            AddBooking(v, c);
            v.RentedStatus = RentedStatus.Rented;
        }

            _waitForFinish = false;
        }
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

    #region Methods for adding vehicles, bookings and customers.
    public void AddVehicle(string make, string regNo, int odometer, double costKm, RentedStatus status, VehicleTypes type)
    {
        if (make == string.Empty || regNo == string.Empty || odometer == 0 || costKm == 0 || _costday == 0 || status != RentedStatus.Available)
        {
            error = "Can not add vehicle, try again.";
        }
        else
        {
            error = string.Empty;
            switch (type)
            {
                case VehicleTypes.Motorcycle:
                    _db.Add<Vehicle>(new Motorcycle(){ Id = _db.NextVehicleId, RegistrationNo = regNo, Make = make, Odometer = odometer, CostPerKm = costKm, CostPerDay = _costday, RentedStatus = status, VehicleType = type });
                    break;
                default:
                    _db.Add<Vehicle>(new Car(){ Id = _db.NextVehicleId, RegistrationNo = regNo, Make = make, Odometer = odometer, CostPerKm = costKm, CostPerDay = _costday, RentedStatus = status, VehicleType = type} );
                    break;
            }
            SetDefaultValues();
        }
    }
    public void AddCustomers(int id, int ssn, string firstName, string lastName)
    {
        if (ssn != 0 && !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
        {
            _db.Add(new Customer() { Id = _db.NextPersonId, SSN = ssn, FirstName = firstName, LastName = lastName });
            error = string.Empty;
            SetDefaultValues();
        }
        else
            error = "Can not add customer, try again.";
    }
    public void AddBooking(Vehicle vehicle, Customer customer)
    {
        DateOnly d = DateOnly.FromDateTime(DateTime.Now);

        if (vehicle is null || customer is null)
        {
            error = "Can not add booking, try again.";
        }
        else
        {
            _db.Add(new Booking
            {
                Id = _db.NextBookingId,
                RegistrationNo = vehicle.RegistrationNo,
                Customer = customer,
                KmRented = vehicle.Odometer,
                Rented = d,
                Status = BookingStatus.Open
            });
        }
    }
    #endregion

    #region Tillfällig och ev. onödig kod.

    /// <summary>
    /// Metoder som inte ska användas i slutprodukten.
    /// Ta bort eller ändra dem så de anropar de generiska metoderna.
    /// </summary>
    /// <returns></returns>





    #endregion
}


/*
 

Att göra:


Datalagret:
    - Fixa de generiska metoderna i Data.
    - Läs på om expresions och reflection-metoder.
    - Just nu så är det inga generiska metoder för Get.

Common:

Business:
    - RentVehicle ska ta data från customer och vehicle och lägger ihop till en bokning.
        * Har en Add-metod nu som ska ta in ett vehicle och en booking, skapa ett booking objekt.
        * Det som är kvar att göra är att se hur jag får ut ett fordon och en kund mha Expression-metoder när jag har deras Id:n
    - Måste det vara unika SSN??
    - Fixa dropdown arrayerna

Index:
    - När add-button klickas så ska fälten rensas.
 
 */
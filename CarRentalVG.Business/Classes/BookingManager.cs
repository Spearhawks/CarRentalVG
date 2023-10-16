using CarRentalVG.Common.Classes;
using CarRentalVG.Common.Enums;
using CarRentalVG.Common.Extensions;
using CarRentalVG.Common.Interfaces;
using CarRentalVG.Data.Interfaces;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace CarRentalVG.Business.Classes;

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
    public int _kmreturned = 0;
    public string _regno = string.Empty;
    public string _make = string.Empty;
    public int _odom;
    public double _costkm;
    public int _costday;
    public VehicleTypes _vehicletype;
    public RentedStatus _rentedStatus;
    public string error = string.Empty;
    public static DateOnly startDate;
    public static DateOnly endDate = DateOnly.FromDateTime(DateTime.Now);
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

    public IEnumerable<Vehicle> GetVehicles(RentedStatus status = default)
    {
        Expression<Func<Vehicle, bool>> expression = vehicle => vehicle.Id > 0;
        return _db.Get(expression);
    }
    public IEnumerable<Customer> GetCustomers()
    {
        Expression<Func<Customer, bool>> expression = customer => customer is IPerson;
        return _db.Get(expression);
    }
    public IEnumerable<IBooking> GetBookings()
    {
        Expression<Func<Booking, bool>> expression = booking => booking.Id > 0;
        return _db.Get(expression);
    }

    #endregion

    #region Methods for renting and returning vehicles.
    public async Task<IBooking> RentVehicle(int vehicleId, int customerId)
    {
        if (customerId != 0 && vehicleId != 0)
        {
            _waitForFinish = true;

            await Task.Delay(5000);

            var c = GetCustomers().Single(x => x.Id == customerId);
            var v = GetVehicles().Single(x => x.Id == vehicleId);

            if (v.RentedStatus.Equals(RentedStatus.Available))
            {
                AddBooking(v, c);
                v.RentedStatus = RentedStatus.Rented;
            }
            _waitForFinish = false;
        }
        return null;
    }
    public IBooking ReturnVehicle(int vehicleID, int distance)
    {
        var v = GetVehicles().Single(x => x.Id == vehicleID && x.RentedStatus == RentedStatus.Rented);
        var b = GetBookings().Single(x => x.RegistrationNo == v.RegistrationNo && x.Status == BookingStatus.Open);

        if (b != null)
        {
            duration = b.Rented.Duration(endDate);

            v.Odometer += distance;
            v.RentedStatus = RentedStatus.Available;

            b.Cost = Math.Round((distance * v.CostPerKm + v.CostPerDay * duration), 2);
            b.Returned = endDate;
            b.Status = BookingStatus.Closed;
            b.KmReturned = v.Odometer;
            
            return b;
        }
        return null;
    }

    #endregion

    #region Methods for adding vehicles, bookings and customers.
    public void AddVehicle(string make, string regNo, int odometer, double costKm, RentedStatus status, VehicleTypes type)
    {
        string pattern = @"^[A-Z]{3}\d{3}$|^[A-Z]{3}\d{2}[A-Z]$";
        
        if(!Regex.IsMatch(regNo, pattern))
        {
            error = "The registrationnumber is incorrect formated, try again.";
        }
        else
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
                        _db.Add<Vehicle>(new Motorcycle() { Id = _db.NextVehicleId, RegistrationNo = regNo, Make = make, Odometer = odometer, CostPerKm = costKm, CostPerDay = _costday, RentedStatus = status, VehicleType = type });
                        break;
                    default:
                        _db.Add<Vehicle>(new Car() { Id = _db.NextVehicleId, RegistrationNo = regNo, Make = make, Odometer = odometer, CostPerKm = costKm, CostPerDay = _costday, RentedStatus = status, VehicleType = type });
                        break;
                }
                SetDefaultValues();
            }
        }
    }
    public void AddCustomers(int ssn, string firstName, string lastName)
    {
        if(GetCustomers().Any(c => c.SSN == ssn))
        {
            error = "SSN already in the list, try again.";
        }
        else
        {
            if (ssn != 0 && !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                _db.Add(new Customer() { Id = _db.NextPersonId, SSN = ssn, FirstName = firstName, LastName = lastName });
                error = string.Empty;
                SetDefaultValues();
            }
            else error = "Can not add customer, try again.";
        }
    }
    public void AddBooking(Vehicle vehicle, Customer customer)
    {
        startDate = DateOnly.FromDateTime(DateTime.Now);

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
                Rented = startDate,
                Status = BookingStatus.Open
            });
        }
    }
    #endregion

    #region Unused code
    //public string[] VehicleStatusNames => _db.RentedStatusNames;
    //public string[] VehicleTypeNames => _db.VehicleTypeNames;
    //public VehicleTypes GetVehicleType(string name) => _db.GetVehicleType(name);
    // public IPerson? GetPerson(string ssn) { return null; }
    // public IVehicle? GetVehicle(int vehicleId) { return null; }
    // public IVehicle? GetVehicle(string regNo) { return null; }
    // public Vehicle? GetVehicle(int vehicleId)
    #endregion
}



/*
Att göra:

Generellt:
    - Try/catch?
    - Ge mer specifika felmeddelanden?
    - Kolla över getter/setters.
    - Rensa bort onödiga variablar.
    - Kolla över vilka variablar och properties som kan sättas private/readonly och använda metoder och eller props för att hämta. 

Datalagret:
    - Fixa så att GetSingle() fungerar? Den behövs inte direkt.

Common:

Business:
    - Unika SSN.
    - Fixa dropdown arrayerna?
    - Rensa cost efter return? Textfält rensas på focus ändå.

Index:
    - Ordna dropdown default och rensning.
 */
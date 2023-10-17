using CarRentalVG.Common.Classes;
using CarRentalVG.Common.Enums;
using CarRentalVG.Common.Interfaces;
using CarRentalVG.Data.Interfaces;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace CarRentalVG.Data.Classes;

public class Data : IData
{
    #region Lists and constructor

    private readonly List<Customer> _customers = new();
    private readonly List<Booking> _bookings = new();
    private readonly List<Vehicle> _vehicles = new();

    public Data() => SeedData();

    #endregion

    #region Methods for seeding the initial lists and adding Id to the objects in the list.
    private void SeedData()
    {
        var todayDate = DateOnly.FromDateTime(DateTime.Today);
        var rentedDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-1));

        _customers.Add(new Customer { Id = NextPersonId, SSN = 1, FirstName = "John", LastName = "Doe" });
        _customers.Add(new Customer { Id = NextPersonId, SSN = 2, FirstName = "The", LastName = "Rock" });
        _customers.Add(new Customer { Id = NextPersonId, SSN = 3, FirstName = "Dwayne", LastName = "Johnson" });
        _customers.Add(new Customer { Id = NextPersonId, SSN = 4, FirstName = "Bobba", LastName = "Fett" });
        _vehicles.Add(new Car { Id = NextVehicleId, RegistrationNo = "ABC123", Make = "Volvo", Odometer = 3333, CostPerKm = 1.3, CostPerDay = 100, RentedStatus = RentedStatus.Rented, VehicleType = VehicleTypes.Van });
        _vehicles.Add(new Car { Id = NextVehicleId, RegistrationNo = "CBA321", Make = "Opel", Odometer = 1111, CostPerKm = 1.1, CostPerDay = 200, RentedStatus = RentedStatus.Available, VehicleType = VehicleTypes.Combi });
        _bookings.Add(new Booking { Id = NextBookingId, RegistrationNo = "ABC123", Customer = _customers[0], KmRented = 3333, Rented = rentedDate, Cost = default, Status = BookingStatus.Open });
    }
    public int NextVehicleId => _vehicles.Count.Equals(0) ? 1 : _vehicles.Max(b => b.Id) + 1;
    public int NextPersonId => _customers.Count.Equals(0) ? 1 : _customers.Max(b => b.Id) + 1;
    public int NextBookingId => _bookings.Count.Equals(0) ? 1 : _bookings.Max(b => b.Id) + 1;

    #endregion

    #region Generic methods for getting and adding data to the lists.

    public void Add<T>(T item)
    {
        var t = item.GetType();
        Console.WriteLine(t);

        
        
        // Inte generiskt nog
        if(item is Vehicle) { _vehicles.Add(item as Vehicle); }
        else if( item is IPerson) { _customers.Add((Customer)(IPerson)item); }
        else if( item is Booking) { _bookings.Add((Booking)(IBooking)item); }
    }
    public List<T> Get<T>(Expression<Func<T, bool>>? expression = null)
    {
        var t = typeof(List<>).MakeGenericType(typeof(T));
        FieldInfo? fieldInfo = GetType().GetField($"_{typeof(T).Name.ToLower()}s", BindingFlags.NonPublic | BindingFlags.Instance);

        if (fieldInfo != null)
        {
            if (fieldInfo.FieldType == t)
            {
                List<T>? items = (List<T>)fieldInfo.GetValue(this);
                return items.Where(expression.Compile()).ToList();
            }
            else
            {
                throw new ArgumentException($"Field '{fieldInfo.Name}' is not of type List<{typeof(T).Name}>.");
            }
        }
        else
        {
            throw new ArgumentException($"No such field found for type {typeof(T).Name}.");
        }
    }

    #endregion

    #region Unused code
    //public string[] RentedStatusNames { get; set; }
    //public string[] VehicleTypeNames { get; set; }
    //public VehicleTypes GetVehicleType(string name)
    //{
    //    throw new NotImplementedException();
    //}

    //public T? GetSingle<T>(Expression<Func<T, bool>>? expression)
    //{
    //    throw new NotImplementedException();
    //}

    #endregion
}

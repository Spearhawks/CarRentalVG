using CarRentalVG.Common;
using CarRentalVG.Common.Classes;
using CarRentalVG.Common.Enums;
using CarRentalVG.Common.Interfaces;
using CarRentalVG.Data.Interfaces;
using System.Linq.Expressions;

namespace CarRentalVG.Data.Classes;

public class Data : IData
{
    #region Lists and constructor
    private List<IPerson> _persons = new();
    private List<IBooking> _bookings = new List<IBooking>();
    private List<IVehicle> _vehicles = new List<IVehicle>();

    public Data() => SeedData();

    #endregion

    #region Methods for seeding the initial lists and adding Id to the objects in the list.

    private void SeedData()
    {
        var todayDate = DateOnly.FromDateTime(DateTime.Today);
        var rentedDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-5));

        _persons.Add(new Customer { Id = NextPersonId, SSN = 1, FirstName = "John", LastName = "Doe" });
        _persons.Add(new Customer { Id = NextPersonId, SSN = 2, FirstName = "The", LastName = "Rock" });
        _persons.Add(new Customer { Id = NextPersonId, SSN = 3, FirstName = "Dwayne", LastName = "Johnson" });
        _persons.Add(new Customer { Id = NextPersonId, SSN = 4, FirstName = "Bobba", LastName = "Fett" });
        _vehicles.Add(new Car( NextVehicleId, "ABC123", "Volvo", 3233, 1.2, 300, RentedStatus.Rented, VehicleTypes.Van));
        _vehicles.Add(new Car( NextVehicleId, "CBA321", "Opel", 1111, 1.1, 200, RentedStatus.Available, VehicleTypes.Combi));
        _bookings.Add(new Booking { Id = NextBookingId, RegistrationNo = "ABC123", Customer = (Customer)_persons[0], KmRented = 3233, KmReturned = 0, Rented = rentedDate, Cost = default, Status = BookingStatus.Open });
    }
    public int NextVehicleId => _vehicles.Count.Equals(0) ? 1 : _vehicles.Max(b => b.Id) + 1;
    public int NextPersonId => _persons.Count.Equals(0) ? 1 : _persons.Max(b => b.Id) + 1;
    public int NextBookingId => _bookings.Count.Equals(0) ? 1 : _bookings.Max(b => b.Id) + 1;


    #endregion

    #region Generic methods for getting and adding data to the lists.
    public void Add<T>(T item)
    {
        if (item.GetType().Equals(typeof(Vehicle)))
        {
            _vehicles.Add((IVehicle)item);
        }
        else if(item.GetType().Equals(typeof(IPerson)))
        {
            _persons.Add((IPerson)item);
        }
        
    }

    public List<T> Get<T>(Expression<Func<T, bool>>? expression)
    {
        throw new NotImplementedException();
    }
       
    public T? GetSingle<T>(Expression<Func<T, bool>>? expression)
    {
        throw new NotImplementedException();
    }

    public VehicleTypes GetVehicleType(string name)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Tillfällig och kod utan ev. behov.

    /// <summary>
    /// Dessa använder jag bara tills jag har fixat de generiska metoderna.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<IVehicle> GetVehicles() => _vehicles;
    public IEnumerable<IBooking> GetBookings() => _bookings;
    public IEnumerable<IPerson> GetPersons() => _persons;
    public void AddPers(Customer c)
    {
        _persons.Add(c);
    }

    public void AddBooking()
    {

    }

    //public List<IPerson> GetPersons()
    //{
    //    throw new NotImplementedException();
    //}

    // ReturnVehicle() + ReturnVehicle()
    // Add() generisk.
    // GetSingle() generisk.
    // GetAll() generisk
    // 

    // Får ut arrays med enum konstanter, kolla upp mer hur dessa ska användas. Ev. behövs de inte.
    //public string[] RentedStatusNames { get; set; }
    //public string[] VehicleTypeNames { get; set; }

    #endregion
}

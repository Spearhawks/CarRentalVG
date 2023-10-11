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
    private List<IBooking> _bookings = new();
    private List<Vehicle> _vehicles = new();

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
        _vehicles.Add(new Car { Id = NextVehicleId, RegistrationNo = "ABC123", Make = "Volvo", Odometer = 3333, CostPerKm = 1.3, CostPerDay = 100, RentedStatus = RentedStatus.Rented, VehicleType = VehicleTypes.Van });
        _vehicles.Add(new Car { Id = NextVehicleId, RegistrationNo = "CBA321", Make = "Opel", Odometer = 1111, CostPerKm = 1.1, CostPerDay = 200, RentedStatus = RentedStatus.Available, VehicleType = VehicleTypes.Combi });
        _bookings.Add(new Booking { Id = NextBookingId, RegistrationNo = "ABC123", Customer = (Customer)_persons[0], KmRented = 3333, KmReturned = 0, Rented = rentedDate, Cost = default, Status = BookingStatus.Open });
    }
    public int NextVehicleId => _vehicles.Count.Equals(0) ? 1 : _vehicles.Max(b => b.Id) + 1;
    public int NextPersonId => _persons.Count.Equals(0) ? 1 : _persons.Max(b => b.Id) + 1;
    public int NextBookingId => _bookings.Count.Equals(0) ? 1 : _bookings.Max(b => b.Id) + 1;

    #endregion

    #region Generic methods for getting and adding data to the lists.
    public void Add<T>(T item)
    {
        if(item is Vehicle) { _vehicles.Add(item as Vehicle); }
        else if( item is IPerson) { _persons.Add((IPerson)item); }
        else if( item is Booking) { _bookings.Add((IBooking)item); }
    }
    public List<T> Get<T>(Expression<Func<T, bool>>? expression)
    {
        if (typeof(T) == typeof(Vehicle)) { return _vehicles.OfType<T>().ToList(); }
        else if (typeof(T) == typeof(Booking)) { return _bookings.OfType<T>().ToList(); }
        else if (typeof(T) == typeof(Customer)) { return _persons.OfType<T>().ToList(); }
        else throw new Exception(); 
    }
    public T? GetSingle<T>(Expression<Func<T, bool>>? expression)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Methods for getting types to dropdowns
    public string[] RentedStatusNames { get; set; }
    public string[] VehicleTypeNames { get; set; }
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

    // Kommer jag behöva denna?
    //public List<IPerson> GetPersons()
    //{
    //    throw new NotImplementedException();
    //}

    // Får ut arrays med enum konstanter, ska fylla på dropdowns.


    #endregion
}

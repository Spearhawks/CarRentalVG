using CarRentalVG.Common.Classes;
using CarRentalVG.Common.Enums;
using CarRentalVG.Common.Interfaces;
using System.Linq.Expressions;

namespace CarRentalVG.Data.Interfaces;
public interface IData
{
    public int NextVehicleId { get; }
    public int NextPersonId { get; }
    public int NextBookingId { get; }
    public void Add<T>(T item);
    public List<T> Get<T>(Expression<Func<T, bool>>? expression);

    public VehicleTypes GetVehicleType(string name);
    public IEnumerable<IPerson> GetPersons();
    IEnumerable<IVehicle> GetVehicles();
    IEnumerable<IBooking> GetBookings();

    // Tillfällig metod

    //public string[] RentedStatusNames { get; set; }
    //public string[] VehicleTypeNames { get; set; }
    //public void AddPers(Customer c);
}

using CarRentalVG.Common.Classes;
using CarRentalVG.Common.Enums;
using CarRentalVG.Common.Interfaces;

namespace CarRentalVG.Data.Interfaces;
public interface IData
{
    public int NextVehicleId { get; }
    public int NextPersonId { get; }
    public int NextBookingId { get; }

    //public string[] RentedStatusNames { get; set; }
    //public string[] VehicleTypeNames { get; set; }

    public VehicleTypes GetVehicleType(string name);
    public IEnumerable<IPerson> GetPersons();
    public void Add<T>(T item);

    // Tillfällig metod
    public void AddPers(Customer c);


    
    IEnumerable<IVehicle> GetVehicles();
    IEnumerable<IBooking> GetBookings();
}

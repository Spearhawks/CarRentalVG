using CarRentalVG.Common.Classes;
using CarRentalVG.Common.Enums;
using CarRentalVG.Common.Interfaces;

namespace CarRentalVG.Data.Interfaces;
public interface IData
{
    public string[] RentedStatusNames { get; set; }
    public string[] VehicleTypeNames { get; set; }
    public VehicleTypes GetVehicleType(string name);
    public IEnumerable<IPerson> GetPersons();
    //public void Add<T>();

    // Tillfällig metod
    public void AddPers(Customer c);
    IEnumerable<IVehicle> GetVehicles();
    IEnumerable<IBooking> GetBookings();
}

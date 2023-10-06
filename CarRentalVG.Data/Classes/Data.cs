using CarRentalVG.Common.Enums;
using CarRentalVG.Common.Interfaces;
using CarRentalVG.Data.Interfaces;
using System.Linq.Expressions;

namespace CarRentalVG.Data.Classes;

public class Data : IData
{
    readonly List<IPerson> _persons = new List<IPerson>();
    readonly List<IBooking> _booking = new List<IBooking>();
    readonly List<IVehicle> _vehicle = new List<IVehicle>();

    public Data() => SeedData();

    private void SeedData()
    {
        // Läs in jsonfiler för vehicle och customers.
    }

    // Dessa genererar ett fake Id för de olika posterna i listorna. Anropa vid skapande av ett item.
    public int NextVehicleId => _booking.Count.Equals(0) ? 1 : _vehicle.Max(b => b.Id) + 1;
    public int NextPersonId => _persons.Count.Equals(0) ? 1 : _persons.Max(b => b.Id) + 1;
    public int NextBookingId => _booking.Count.Equals(0) ? 1 : _persons.Max(b => b.Id) + 1;


    // Får ut arrays med enum konstanter, kolla upp mer hur dessa ska användas.
    public string[] VehicleTypeNames => throw new NotImplementedException();

    public string[] RentedStatusNames => throw new NotImplementedException();
    public VehicleTypes GetVehicleType(string name)
    {
        throw new NotImplementedException();
    }

    // Generiska metoder för Add och get.
    public void Add<T>(T item)
    {
        throw new NotImplementedException();
    }

    public List<T> Get<T>(Expression<Func<T, bool>>? expression)
    {
        throw new NotImplementedException();
    }
       
    public T? GetSingle<T>(Expression<Func<T, bool>>? expression)
    {
        throw new NotImplementedException();
    }

    // ReturnVehicle() + ReturnVehicle()
    // Add() generisk.
    // GetSingle() generisk.
    // GetAll() generisk
    // 

}

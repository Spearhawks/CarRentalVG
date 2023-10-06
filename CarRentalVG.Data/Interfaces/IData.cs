using CarRentalVG.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalVG.Data.Interfaces;
public interface IData
{
    List<T> Get<T>(Expression<Func<T, bool>>? expression);
    T? GetSingle<T>(Expression<Func<T, bool>>? expression);
    public void Add<T>(T item);

    int NextVehicleId {  get; }
    int NextPersonId { get; }
    int NextBookingId { get; }

    string[] VehicleTypeNames { get; }
    string[] RentedStatusNames { get; }
    public VehicleTypes GetVehicleType(string name);
}

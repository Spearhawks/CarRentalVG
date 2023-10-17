using System.Linq.Expressions;

namespace CarRentalVG.Data.Interfaces;
public interface IData
{
    public int NextVehicleId { get; }
    public int NextPersonId { get; }
    public int NextBookingId { get; }
    public void Add<T>(T item);
    public List<T> Get<T>(Expression<Func<T, bool>>? expression);
}

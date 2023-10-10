using CarRentalVG.Common.Enums;
using CarRentalVG.Common.Interfaces;

namespace CarRentalVG.Common.Classes;
public class Vehicle : IVehicle
{
    public int Id {get; init;}
    public string RegistrationNo { get; set; }
    public string Make { get; set; }
    public int Odometer { get; set; }
    public double CostPerKm { get; set; }
    public int CostPerDay { get; set; }
    public VehicleTypes VehicleType { get; set; }
    public RentedStatus RentedStatus { get; set; } = RentedStatus.Available;

    public Vehicle(int id, string regNo, string make, int odometer, double costKm, int costDay, VehicleTypes vehicleType, RentedStatus status)
        => (Id, RegistrationNo, Make, Odometer, CostPerKm, CostPerDay, VehicleType, RentedStatus)
        = (id, regNo, make, odometer, costKm, costDay, vehicleType, status);

    public Vehicle()
    {
    }
}

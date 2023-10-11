using CarRentalVG.Common.Enums;

namespace CarRentalVG.Common.Classes;
public class Vehicle
{
    public int Id {get; init;}
    public string RegistrationNo { get; set; }
    public string Make { get; set; }
    public int Odometer { get; set; }
    public double CostPerKm { get; set; }
    public int CostPerDay { get; set; }
    public VehicleTypes VehicleType { get; set; }
    public RentedStatus RentedStatus { get; set; } = RentedStatus.Available;
}

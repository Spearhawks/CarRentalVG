using CarRentalVG.Common.Enums;

namespace CarRentalVG.Common.Classes;
public class Vehicle
{
    public int Id {get; init;}
    public string RegistrationNo { get; init; }
    public string Make { get; init; }
    public int Odometer { get; set; }
    public double CostPerKm { get; init; }
    public int CostPerDay { get; init; }
    public VehicleTypes VehicleType { get; init; }
    public RentedStatus RentedStatus { get; set; } = RentedStatus.Available;
    public int KmReturned { get; set; }
}

using CarRentalVG.Common.Enums;

namespace CarRentalVG.Common.Classes;
public class Motorcycle : Vehicle
{
    public Motorcycle(int id, string regNo, string make, int odoMe, double costKm, int costDay, RentedStatus rentStatus, VehicleTypes vType = VehicleTypes.Motorcycle) : base()
    {
        Id = id;
        RegistrationNo = regNo;
        Make = make;
        Odometer = odoMe;
        CostPerKm = costKm;
        CostPerDay = costDay;
        VehicleType = vType;
        RentedStatus = rentStatus;
    }
}

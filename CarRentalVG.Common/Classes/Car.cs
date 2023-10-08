using CarRentalVG.Common.Enums;

namespace CarRentalVG.Common.Classes;
public class Car : Vehicle
{
    public Car(string regNo, string make, int odoMe, double costKm, int costDay, VehicleTypes vType, RentedStatus rentStatus) : base() 
    {
        RegistrationNo = regNo;
        Make = make;
        Odometer = odoMe;
        CostPerKm = costKm;
        CostPerDay = costDay;
        VehicleType = vType;
        RentedStatus = rentStatus;
    }

}

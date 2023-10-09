﻿using CarRentalVG.Common.Enums;

namespace CarRentalVG.Common.Classes;
public class Car : Vehicle
{
    public Car(int id, string regNo, string make, int odoMe, double costKm, int costDay, VehicleTypes vType, RentedStatus rentStatus) : base() 
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

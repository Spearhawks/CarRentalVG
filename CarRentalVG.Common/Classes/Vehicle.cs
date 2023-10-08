using CarRentalVG.Common.Enums;
using CarRentalVG.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalVG.Common.Classes;
public class Vehicle : IVehicle
{
    public int Id {get; private set;}
    public string RegistrationNo { get; set; }
    public int Odometer { get; set; }
    public double CostPerKm { get; set; }
    public int CostPerDay { get; set; }
    public object VehicleType { get; set; }
    public RentedStatus RentedStatus { get; set; }

    public string Make { get; set; }

}

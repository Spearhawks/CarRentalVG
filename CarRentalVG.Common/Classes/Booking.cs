using CarRentalVG.Common.Enums;
using CarRentalVG.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalVG.Common.Classes;
public class Booking : IBooking
{
    public string RegistrationNo { get; set; }
    public Customer Customer { get; set; }
    public int KmRented { get; set; }
    public int KmReturned { get; set; }
    public DateOnly Rented { get; set; }
    public DateOnly Returned { get; set; }
    public double Cost { get; set; }
    public BookingStatus Status { get; set; }

    public string CustomerOut(Customer c)
    {
        return $"{c.LastName} {c.FirstName} ({c.SSN})";
    }
}

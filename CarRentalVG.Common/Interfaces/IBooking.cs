using CarRentalVG.Common.Classes;
using CarRentalVG.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalVG.Common.Interfaces;
public interface IBooking
{
    public int Id { get; init; }
    public string RegistrationNo { get; init; }
    public Customer Customer { get; set; }
    public int KmRented { get; set; }
    public int KmReturned { get; set; }
    public DateOnly Rented { get; set; }
    public DateOnly Returned { get; set; }
    public double Cost { get; set; }
    public BookingStatus Status { get; set; }
    public string CustomerOut(Customer c);
}

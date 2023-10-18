using CarRentalVG.Common.Interfaces;

namespace CarRentalVG.Common.Classes;
public class Customer : IPerson
{
    public int Id { get; init; }
    public int SSN { get; init; }
    public string FirstName { get; set;}
    public string LastName { get; set; }
}

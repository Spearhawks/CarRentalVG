﻿namespace CarRentalVG.Common.Interfaces;
public interface IPerson
{
    public int Id { get; init; }
    public int SSN { get; init; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

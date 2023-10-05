using CarRentalVG.Data.Interfaces;

namespace CarRentalVG.Business;

public class BookingManager
{
    private readonly IData _db;
    public BookingManager(IData db) => _db = db;



}


/*
 

Att göra:

Interface:
    - Skapa inputs och dropdowns och knappar m.m.
    - Justera tabellplacering.


Datalagret:
    - Skapa generiska metoder i Data.
    - Läsa in JSON-filer.
    - Läs på om expresions och reflection-metoder.
    - Här ska metoder för att hyra och lämna tillbaka finnas.

Common:
    - Car och Motrocycle ska ärva från Vehicle.
    - Läs på om arv.

Business:
    - RentVehicle metoden ska vara asynkron och låsa alla knappar i typ 10 sekunder.









 
 */
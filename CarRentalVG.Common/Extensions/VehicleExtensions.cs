namespace CarRentalVG.Common.Extensions;
public static class VehicleExtensions
{
    public static int Duration(this DateOnly startDate, DateOnly endDate)
    {
        return endDate.Day - startDate.Day;
    }
}

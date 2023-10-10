using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalVG.Common.Extensions;
public static class VehicleExtensions
{
    public static int Duration(this DateOnly startDate, DateOnly endDate)
    {
        return endDate.Day - startDate.Day;
    }
}

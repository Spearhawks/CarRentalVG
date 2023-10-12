using CarRentalVG.Common.Extensions;
using System.Security.Cryptography.X509Certificates;

namespace CarRentalVG.Common.Exceptions;
public class CustomException : Exception
{
    public CustomException(string? error, Exception? innerException) : base(error, innerException) { }
}

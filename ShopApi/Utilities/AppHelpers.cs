using System.Security.Cryptography;

namespace ShopApi.Utilities;

public class AppHelpers
{
    public static int GenerateRandomNumber()
    {
        var currentYear = DateTime.Now.Year;
        var nextNumber = RandomNumberGenerator.GetInt32(currentYear, int.MaxValue);
        return currentYear + nextNumber;
    }
}
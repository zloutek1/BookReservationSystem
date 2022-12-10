using System.Security.Cryptography;

namespace BookReservationSystem.BL.Helpers;

public sealed class SecurityHelper : ISecurityHelper
{
    public string GenerateSalt()
    {
        var saltBytes = new byte[24];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(saltBytes);
        return Convert.ToBase64String(saltBytes);
    }

    public string HashPassword(string password, string salt)
    {
        var saltedPassword = Convert.FromBase64String(password + salt);
        using var alg = SHA512.Create();
        var hashedBytes = alg.ComputeHash(saltedPassword);
        return Convert.ToBase64String(hashedBytes);
    }
}

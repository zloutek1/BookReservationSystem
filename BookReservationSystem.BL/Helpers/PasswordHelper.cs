namespace BookReservationSystem.BL.Helpers;

public class SecurityHelper
{
    public static string GenerateSalt()
    {
        var saltBytes = new byte[24];

        using (var provider = new RNGCryptoServiceProvider())
        {
            provider.GetNonZeroBytes(saltBytes);
        }

        return Convert.ToBase64String(saltBytes);
    }

    public static string HashPassword(string password, string salt)
    {
        var saltBytes = Convert.FromBase64String(salt);

        using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, 24, 1000))
        {
            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(nHash));
        }
    }
}

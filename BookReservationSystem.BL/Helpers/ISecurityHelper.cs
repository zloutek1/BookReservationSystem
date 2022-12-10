namespace BookReservationSystem.BL.Helpers;

public interface ISecurityHelper
{
    string GenerateSalt();
    string HashPassword(string password, string salt);
}
using StringCalculator.Core.Entities;


namespace StringCalculator.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(AppUser appUser);
    }
}

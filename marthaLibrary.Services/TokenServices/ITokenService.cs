using marthaLibrary.CoreData.DatabaseModels;

namespace marthaLibrary.Services.TokenServices
{
    public interface ITokenService
    {
        string GenerateToken(ResetCode code, AppUser user);
        string GenerateToken(AppUser user);
    }
}
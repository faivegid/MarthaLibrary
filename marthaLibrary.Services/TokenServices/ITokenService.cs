using marthaLibrary.CoreData.DatabaseModels;

namespace marthaLibrary.Services.TokenServices
{
    public interface ITokenService
    {
        string GenerateToken(AppUser user);
    }
}
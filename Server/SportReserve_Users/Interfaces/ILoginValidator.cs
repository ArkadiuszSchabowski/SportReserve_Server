using Microsoft.AspNetCore.Identity;
using SportReserve_Users_Db.Entities;

namespace SportReserve_Users.Interfaces
{
    public interface ILoginValidator
    {
        void ThrowIfUserNotFound(User? user);
        void ThrowIfInvalidLogin(PasswordVerificationResult result);
        void ThrowIfPasswordsDoNotMatch(string password, string repeatPassword);
        void ValidatePassword(PasswordVerificationResult result);
    }
}
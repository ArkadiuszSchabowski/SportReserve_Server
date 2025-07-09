using Microsoft.AspNetCore.Identity;
using SportReserveDatabase.Entities;

namespace SportReserveServer.Interfaces
{
    public interface ILoginValidator
    {
        void ThrowIfUserNotFound(User? user);
        void ThrowIfInvalidLogin(PasswordVerificationResult result);
        void ThrowIfPasswordsDoNotMatch(string password, string repeatPassword);
        void ValidatePassword(PasswordVerificationResult result);
    }
}
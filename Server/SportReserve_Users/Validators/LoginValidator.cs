using Microsoft.AspNetCore.Identity;
using SportReserve_Shared.Exceptions;
using SportReserveDatabase.Entities;
using SportReserveServer.Interfaces;

namespace SportReserveServer.Validators
{
    public class LoginValidator : ILoginValidator
    {
        public void ThrowIfUserNotFound(User? user)
        {
            if (user == null)
            {
                throw new BadRequestException("Incorrect login details.");
            }
        }

        public void ThrowIfInvalidLogin(PasswordVerificationResult password)
        {
            if (password == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Incorrect login details.");
            }
        }
        public void ThrowIfPasswordsDoNotMatch(string password, string repeatPassword)
        {
            if (password != repeatPassword)
            {
                throw new BadRequestException("Passwords do not match.");
            }
        }

        public void ValidatePassword(PasswordVerificationResult result)
        {
            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid password.");
            }
        }
    }
}


using Microsoft.AspNetCore.Identity;
using SportReserveDatabase.Entities;
using SportReserveServer.Exceptions;
using SportReserveServer.Interfaces;

namespace SportReserveServer.Validators
{
    public class LoginValidator : ILoginValidator
    {
        public void ThrowIfUserNotFound(User? user)
        {
            if (user == null)
            {
                throw new BadRequestException("Błędne dane logowania!");
            }
        }

        public void ThrowIfInvalidLogin(PasswordVerificationResult password)
        {
            if (password == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Błędne dane logowania!");
            }
        }
        public void ThrowIfPasswordsDoNotMatch(string password, string repeatPassword)
        {
            if (password != repeatPassword)
            {
                throw new BadRequestException("Wprowadzone hasła są różne!");
            }
        }

        public void ValidatePassword(PasswordVerificationResult result)
        {
            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Wprowadzono niepoprawne hasło!");
            }
        }

    }
}


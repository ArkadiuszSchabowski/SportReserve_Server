using SportReserve_Shared.Exceptions;
using SportReserve_Users.Interfaces;
using System.Text.RegularExpressions;

namespace SportReserve_Users.Validators
{
    public class EmailValidator : IEmailValidator
    {
        private static readonly Regex EmailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)+$");
        public void ValidateEmail(string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new BadRequestException("Email address cannot be empty.");
            }

            email = email.Trim();

            if (!EmailRegex.IsMatch(email))
            {
                throw new BadRequestException("Invalid email address format.");
            }
        }
    }
}

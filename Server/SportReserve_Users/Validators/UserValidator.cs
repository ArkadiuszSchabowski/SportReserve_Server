using SportReserve_Shared.Exceptions;
using SportReserve_Shared.Interfaces.Base;
using SportReserve_Shared.Models.User;
using SportReserve_Users.Interfaces;
using SportReserve_Users_Db.Entities;

namespace SportReserve_Users.Validators
{
    public class UserValidator : IEntityValidator<User>, IUserValidator, IValidatorInput<RegisterDto>
    {
        private readonly IEmailValidator _emailValidator;

        public UserValidator(IEmailValidator emailValidator)
        {
            _emailValidator = emailValidator;
        }

        public void ThrowIfDtoIsNull(RegisterDto? dto)
        {
            if (dto == null)
            {
                throw new NotFoundException("User data is required.");
            }
        }
        public void ThrowIfEntityExist(User? user)
        {
            if (user != null)
            {
                throw new ConflictException("User already exists in database.");
            }
        }

        public void ThrowIfEntityIsNull(User? user)
        {
            if (user == null)
            {
                throw new NotFoundException("User not found.");
            }
        }

        public void ValidateUser(RegisterDto? user)
        {
            ThrowIfDtoIsNull(user);
            _emailValidator.ValidateEmail(user!.Email);        

            if (string.IsNullOrWhiteSpace(user.Name) || user.Name.Length < 3 || user.Name.Length > 25)
            {
                throw new BadRequestException("User name must be between 3 and 25 characters.");
            }

            if (string.IsNullOrWhiteSpace(user.Surname) || user.Surname.Length < 3 || user.Surname.Length > 25)
            {
                throw new BadRequestException("User surname must be between 3 and 25 characters.");
            }

            if (user.Password != user.RepeatPassword)
            {
                throw new BadRequestException("Passwords are not the same.");
            }

            if((user.Password.Length < 5 || user.RepeatPassword.Length < 5) || (user.Password.Length > 25 || user.RepeatPassword.Length > 25))
            {
                throw new BadRequestException("Password must be between 5 and 25 characters.");
            }

            if (user.Gender == null)
            {
                throw new BadRequestException("You must choose a gender.");
            }

            if (user.DateOfBirth < DateOnly.Parse("1900-01-01") || user.DateOfBirth > DateOnly.FromDateTime(DateTime.Now))
            {
                throw new BadRequestException("Incorrect date of birth.");
            }
        }
    }
}

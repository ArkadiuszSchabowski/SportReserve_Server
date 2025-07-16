using Microsoft.AspNetCore.Identity;
using SportReserve_Shared.Interfaces;
using SportReserve_Shared.Interfaces.Base;
using SportReserve_Shared.Models.User;
using SportReserve_Users.Interfaces;
using SportReserve_Users.Interfaces.Aggregates;
using SportReserve_Users_Db.Entities;

namespace SportReserve_Users.CompositionRoot
{
    public class UserAggregateValidator : IUserAggregateValidator
    {
        private readonly IEmailValidator _emailValidator;
        private readonly IEntityValidator<User> _entityValidator;
        private readonly IValidatorInput<RegisterDto> _inputValidator;
        private readonly IUserValidator _userValidator;
        private readonly ILoginValidator _loginValidator;
        private readonly IValidatorId _validatorId;

        public UserAggregateValidator(IEmailValidator emailValidator, IEntityValidator<User> entityValidator, IValidatorInput<RegisterDto> inputValidator, IUserValidator userValidator, ILoginValidator loginValidator, IValidatorId validatorId)
        {
            _emailValidator = emailValidator;
            _entityValidator = entityValidator;
            _inputValidator = inputValidator;
            _userValidator = userValidator;
            _loginValidator = loginValidator;
            _validatorId = validatorId;
        }

        public void ThrowIfDtoIsNull(RegisterDto? dto)
        {
            _inputValidator.ThrowIfDtoIsNull(dto);
        }

        public void ThrowIfEntityExist(User? user)
        {
            _entityValidator.ThrowIfEntityExist(user);
        }

        public void ThrowIfEntityIsNull(User? user)
        {
            _entityValidator.ThrowIfEntityIsNull(user);
        }

        public void ThrowIfInvalidLogin(PasswordVerificationResult result)
        {
            _loginValidator.ThrowIfInvalidLogin(result);
        }

        public void ThrowIfPasswordsDoNotMatch(string password, string repeatPassword)
        {
            _loginValidator.ThrowIfPasswordsDoNotMatch(password, repeatPassword);
        }

        public void ThrowIfUserNotFound(User? user)
        {
            _loginValidator.ThrowIfUserNotFound(user);
        }

        public void ValidateEmail(string email)
        {
            _emailValidator.ValidateEmail(email);
        }

        public void ValidateId(int id)
        {
            _validatorId.ValidateId(id);
        }

        public void ValidatePassword(PasswordVerificationResult result)
        {
            _loginValidator.ValidatePassword(result);
        }

        public void ValidateUser(RegisterDto? user)
        {
            _userValidator.ValidateUser(user);
        }
    }
}

using SportReserve_Shared.Models.User;

namespace SportReserve_Users.Interfaces
{
    public interface IValidateRegisterStepOne
    {
        Task ValidateRegisterStepOne(RegisterStepOneDto dto);
    }
}

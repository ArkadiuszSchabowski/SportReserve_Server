using SportReserve_Shared.Interfaces.Base;

namespace SportReserveServer.Validators.Base
{
    public abstract class InputValidator<T> : IValidatorInput<T> where T : class
    {
        public abstract void ThrowIfDtoIsNull(T? dto);
    }
}

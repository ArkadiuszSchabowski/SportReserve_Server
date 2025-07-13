namespace SportReserve_Shared.Interfaces.Base
{
    public interface IValidatorInput<T> where T : class
    {
        void ThrowIfDtoIsNull(T? dto);
    }
}

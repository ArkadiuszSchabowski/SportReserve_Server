namespace SportReserve_Shared.Interfaces.Base
{
    public interface IEntityValidator<T> where T : class
    {
        void ThrowIfEntityExist(T? entity);
        void ThrowIfEntityIsNull(T? entity);
    }
}

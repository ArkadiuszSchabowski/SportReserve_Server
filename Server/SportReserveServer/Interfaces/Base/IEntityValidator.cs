namespace SportReserveServer.Interfaces.Base
{
    public interface IEntityValidator<T> where T : class
    {
        void ThrowIfEntityExist(T? entity);
        void ThrowIfEntityIsNull(T? dto);
    }
}

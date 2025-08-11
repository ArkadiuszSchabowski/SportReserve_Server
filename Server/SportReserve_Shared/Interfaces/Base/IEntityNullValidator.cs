namespace SportReserve_Shared.Interfaces.Base
{
    public interface IEntityNullValidator<T> where T : class
    {
        void ThrowIfEntityIsNull(T? entity);
    }
}

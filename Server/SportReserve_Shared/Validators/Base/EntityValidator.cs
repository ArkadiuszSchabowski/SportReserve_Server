using SportReserve_Shared.Interfaces.Base;

namespace SportReserveServer.Validators.Base
{
    public abstract class EntityValidator<T> : IEntityValidator<T> where T : class
    {
        public abstract void ThrowIfEntityExist(T? entity);
        public abstract void ThrowIfEntityIsNull(T? entity);
    }
}

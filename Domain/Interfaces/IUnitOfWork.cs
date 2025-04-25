namespace ecommerce.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IOrdenCompraRepository Ordenes { get; }
        Task CommitAsync();
    }
}

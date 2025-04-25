using ecommerce.Domain.Entities;
using ecommerce.Domain.Aggregates;

namespace ecommerce.Domain.Interfaces
{
    public interface IOrdenCompraRepository
    {
        IUnitOfWork UnitOfWork { get; }

        Task AddAsync(OrdenCompra orden, CancellationToken cancellationToken = default);
        Task<OrdenCompra?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<OrdenCompra>> GetAllAsync(CancellationToken cancellationToken = default);

        void Update(OrdenCompra orden);
        void Remove(OrdenCompra orden);
    }
}

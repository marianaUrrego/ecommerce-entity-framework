using ecommerce.Domain.Entities;
using ecommerce.Domain.Aggregates;

namespace ecommerce.Domain.Interfaces
{
    public interface IOrdenCompraRepository
    {
        Task AddAsync(OrdenCompra orden);
        Task<OrdenCompra?> GetByIdAsync(Guid id);
        Task<List<OrdenCompra>> GetAllAsync();
    }
}

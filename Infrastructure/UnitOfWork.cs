using ecommerce.Domain.Interfaces;
using ecommerce.Infrastructure.Persistence;

namespace ecommerce.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IOrdenCompraRepository Ordenes { get; }


        public UnitOfWork(AppDbContext context, IOrdenCompraRepository ordenCompraRepository)
        {
            _context = context;
            Ordenes = ordenCompraRepository;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}


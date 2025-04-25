using ecommerce.Domain.Interfaces;
using ecommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using ecommerce.Domain.Entities;
using ecommerce.Domain.Aggregates;

namespace ecommerce.Infrastructure.Repositories
{
    public class OrdenCompraRepository : IOrdenCompraRepository
    {
        private readonly AppDbContext _context;

        public OrdenCompraRepository(AppDbContext context)
        {
            _context = context;
        }

        // Implementa la propiedad UnitOfWork
        public IUnitOfWork UnitOfWork => _context;

        public async Task AddAsync(OrdenCompra orden, CancellationToken cancellationToken = default)
        {
            await _context.Ordenes.AddAsync(orden, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<OrdenCompra?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Ordenes
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        public async Task<List<OrdenCompra>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Ordenes
                .Include(o => o.Items)
                .ToListAsync(cancellationToken);
        }

        // Implementa el método Update
        public void Update(OrdenCompra orden)
        {
            _context.Entry(orden).State = EntityState.Modified;
        }

        // Implementa el método Remove
        public void Remove(OrdenCompra orden)
        {
            _context.Ordenes.Remove(orden);
        }
    }
}

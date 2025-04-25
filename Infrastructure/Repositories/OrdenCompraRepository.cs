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
        private readonly ICacheService _cache;

        public OrdenCompraRepository(AppDbContext context, ICacheService cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task AddAsync(OrdenCompra orden)
        {
            await _context.Ordenes.AddAsync(orden);
        }

        public async Task<OrdenCompra?> GetByIdAsync(Guid id)
        {
            return await _context.Ordenes
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<OrdenCompra>> GetAllAsync()
        {
            return await _context.Ordenes
                .Include(o => o.Items)
                .ToListAsync();
        }
    }
}

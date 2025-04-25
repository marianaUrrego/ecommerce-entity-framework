using Microsoft.EntityFrameworkCore;
using ecommerce.Domain.Entities;
using ecommerce.Domain.Interfaces;
using MediatR;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using ecommerce.Domain.Aggregates;

namespace ecommerce.Infrastructure.Persistence
{
    public class AppDbContext : DbContext, IUnitOfWork
    {
        public DbSet<OrdenCompra> Ordenes { get; set; }
        public DbSet<ItemOrden> ItemsOrden { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // OrdenCompra
            modelBuilder.Entity<OrdenCompra>(oc =>
            {
                oc.HasKey(o => o.Id);

                oc.OwnsOne(o => o.DireccionEntrega);

                oc.HasMany(o => o.Items)
                  .WithOne()
                  .HasForeignKey(i => i.ProductoId);
            });
            // ItemOrden
            modelBuilder.Entity<ItemOrden>()
                .HasKey(i => i.ProductoId); 
        }

        // Implementación de IUnitOfWork
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            await Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            await Database.CommitTransactionAsync(cancellationToken);
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            await Database.RollbackTransactionAsync(cancellationToken);
        }
    }
}

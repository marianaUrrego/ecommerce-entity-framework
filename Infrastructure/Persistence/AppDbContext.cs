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
    public class AppDbContext : DbContext
    {
        public DbSet<OrdenCompra> Ordenes { get; set; }
        public DbSet<ItemOrden> ItemsOrden { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Configura las entidades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapeo de la entidad OrdenCompra
            modelBuilder.Entity<OrdenCompra>()
                .HasKey(o => o.Id); // La clave primaria

            modelBuilder.Entity<OrdenCompra>()
                .HasMany(o => o.Items) // Relación uno a muchos con Items
                .WithOne() // No se especifica una entidad hija en este caso
                .HasForeignKey(i => i.ProductoId); // Relación con ItemOrden

            // Mapeo de la entidad ItemOrden
            modelBuilder.Entity<ItemOrden>()
                .HasKey(i => new { i.ProductoId, i.Cantidad }); // Puedes elegir otra clave primaria
        }

        // Implementación de UnitOfWork
        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await SaveChangesAsync(cancellationToken);
        }

        // Método para guardar cambios en la base de datos
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var result = await SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}

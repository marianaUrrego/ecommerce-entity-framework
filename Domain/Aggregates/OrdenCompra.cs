using ecommerce.Domain.Entities;
using ecommerce.Domain.Events;
using ecommerce.Domain.ValueObjects;

namespace ecommerce.Domain.Aggregates
{
    public class OrdenCompra
    {
        public Guid Id { get; private set; }
        public Guid ClienteId { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public List<ItemOrden> Items { get; private set; } = new();

        public EstadoOrden Estado { get; private set; }
        public DireccionEntrega DireccionEntrega { get; private set; } = null!;

        public decimal Total
        {
            get
            {
                return Items.Sum(i => i.Subtotal);
            }
        }

        protected OrdenCompra() { }

        public OrdenCompra(Guid clienteId, List<ItemOrden> items, DireccionEntrega direccion)
        {
            if (items == null || !items.Any())
                throw new ArgumentException("La orden debe contener al menos un item.");

            Id = Guid.NewGuid();
            ClienteId = clienteId;
            FechaCreacion = DateTime.UtcNow;
            Items = items;
            Estado = EstadoOrden.Creada;
            DireccionEntrega = direccion ?? throw new ArgumentNullException(nameof(direccion));
        }

        public void MarcarComoPagada()
        {
            if (Estado != EstadoOrden.Creada)
                throw new InvalidOperationException("Solo una orden creada puede marcarse como pagada.");

            Estado = EstadoOrden.Pagada;
        }

        public void Cancelar()
        {
            if (Estado == EstadoOrden.Pagada)
                throw new InvalidOperationException("No se puede cancelar una orden ya pagada.");

            Estado = EstadoOrden.Cancelada;
        }
    }
}
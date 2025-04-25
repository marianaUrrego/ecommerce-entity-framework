using ecommerce.Domain.ValueObjects;

namespace ecommerce.Aplicacion.DTOs
{
    public class OrdenCompraDto
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public List<ItemOrdenDto> Items { get; set; } = new();
        public EstadoOrden Estado { get; set; }
        public DireccionEntregaDto DireccionEntrega { get; set; } = null!;
        public decimal Total { get; set; }
    }
}

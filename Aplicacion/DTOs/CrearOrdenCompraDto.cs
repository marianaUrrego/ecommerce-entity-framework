namespace ecommerce.Aplicacion.DTOs
{
    public class CrearOrdenCompraDto
    {
        public Guid ClienteId { get; set; }

        public required DireccionEntregaDto DireccionEntrega { get; set; }

        public required List<ItemOrdenDto> Items { get; set; }
    }
}

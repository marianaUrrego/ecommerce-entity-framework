namespace ecommerce.Aplicacion.DTOs
{
    public class ItemOrdenDto
    {
        public Guid ProductoId { get; set; }
        public required int Cantidad { get; set; }
        public required decimal PrecioUnitario { get; set; }
    }
}

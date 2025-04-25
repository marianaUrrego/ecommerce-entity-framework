namespace ecommerce.Domain.Entities
{
    public class ItemOrden
    {
        public Guid ProductoId { get; private set; }
        public int Cantidad { get; private set; }
        public decimal PrecioUnitario { get; private set; }

        // Calculado automáticamente
        public decimal Subtotal => PrecioUnitario * Cantidad;

        // Constructor requerido por EF Core
        protected ItemOrden() { }

        // Constructor principal
        public ItemOrden(Guid productoId, int cantidad, decimal precioUnitario)
        {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a cero.", nameof(cantidad));

            if (precioUnitario <= 0)
                throw new ArgumentException("El precio unitario debe ser mayor a cero.", nameof(precioUnitario));

            ProductoId = productoId;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
        }

        // Método opcional para modificar la cantidad si hay actualizaciones internas
        public void ActualizarCantidad(int nuevaCantidad)
        {
            if (nuevaCantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a cero.", nameof(nuevaCantidad));

            Cantidad = nuevaCantidad;
        }
    }
}

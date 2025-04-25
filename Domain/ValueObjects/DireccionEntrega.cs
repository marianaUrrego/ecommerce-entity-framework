namespace ecommerce.Domain.ValueObjects
{
    public class DireccionEntrega
    {
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public DireccionEntrega(string ciudad, string direccion)
        {
            if (string.IsNullOrWhiteSpace(ciudad) || string.IsNullOrWhiteSpace(direccion))
                throw new ArgumentException("La dirección no puede estar vacía.");

            Ciudad = ciudad;
            Direccion = direccion;
        }
        protected DireccionEntrega() { }
    }
}

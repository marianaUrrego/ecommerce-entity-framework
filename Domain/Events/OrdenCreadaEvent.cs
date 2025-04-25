using MediatR;

namespace ecommerce.Domain.Events
{
    public class OrdenCreadaEvent : INotification
    {
        public Guid OrdenId { get; }
        public Guid ClienteId { get; }
        public decimal Total { get; }
        public DateTime FechaCreacion { get; }

        public OrdenCreadaEvent(Guid ordenId, Guid clienteId, decimal total)
        {
            OrdenId = ordenId;
            ClienteId = clienteId;
            Total = total;
            FechaCreacion = DateTime.UtcNow;
        }
    }
}

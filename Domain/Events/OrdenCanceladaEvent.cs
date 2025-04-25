using MediatR;

namespace ecommerce.Domain.Events
{
    public class OrdenCanceladaEvent : INotification
    {
        public Guid OrdenId { get; }
        public DateTime FechaCancelacion { get; }

        public OrdenCanceladaEvent(Guid ordenId)
        {
            OrdenId = ordenId;
            FechaCancelacion = DateTime.UtcNow;
        }
    }
}

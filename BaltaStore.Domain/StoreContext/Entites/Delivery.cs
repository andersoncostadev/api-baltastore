using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Shared.Entittes;

namespace BaltaStore.Domain.StoreContext.Entites
{
    public class Delivery : Entity
    {
        public Delivery(DateTime estimatedDeliveryDate)
        {
            CreateDate = DateTime.Now;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }

        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public void Ship()
        {
            Status = EDeliveryStatus.Shipped;
        }

        public void Cancel()
        {
            //Se o status ja tiver como entrtegue não pode cancelar
            Status = EDeliveryStatus.Canceled;
        }
    }
}

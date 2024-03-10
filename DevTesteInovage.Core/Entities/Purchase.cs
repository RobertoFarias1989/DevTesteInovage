using DevTesteInovage.Core.Enums;

namespace DevTesteInovage.Core.Entities
{
    public class Purchase : BaseEntity
    {
        public Purchase(string description, string deliveryAdress)
        {
            Description = description;
            DeliveryAdress = deliveryAdress;

            RegisteredAt = DateTime.Now;
            UpdateredAt = DateTime.Now;
            PurchaseItems = new List<PurchaseItem>();
            Status = PurchaseStatusEnum.Created;
        }

        public string Description { get; private set; }
        public string DeliveryAdress { get; private set; }
        public DateTime RegisteredAt { get; private set; }
        public DateTime UpdateredAt { get; private set; }
        public PurchaseStatusEnum Status { get; private set; }
        public List<PurchaseItem> PurchaseItems{ get; private set; }

        public bool OnTheWay()
        {
            if(Status == PurchaseStatusEnum.Created)
            {
                Status = PurchaseStatusEnum.OnTheWay;
                UpdateredAt = DateTime.Now;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delivered()
        {
            if (Status == PurchaseStatusEnum.OnTheWay)
            {
                Status = PurchaseStatusEnum.Delivered;
                UpdateredAt = DateTime.Now;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Cancel()
        {
            if (!(Status == PurchaseStatusEnum.Delivered))
            {
                Status = PurchaseStatusEnum.Cancelled;
                UpdateredAt = DateTime.Now;
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}

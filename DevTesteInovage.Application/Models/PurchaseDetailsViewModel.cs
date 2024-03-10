using DevTesteInovage.Core.Entities;
using DevTesteInovage.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTesteInovage.Application.Models
{
    public class PurchaseDetailsViewModel
    {
        public PurchaseDetailsViewModel(int id, 
            string description, 
            string deliveryAdress, 
            DateTime registeredAt, 
            DateTime updateredAt, 
            string status, 
            List<PurchaseItemViewModel> purchaseItems)
        {
            Id = id;
            Description = description;
            DeliveryAdress = deliveryAdress;
            RegisteredAt = registeredAt;
            UpdateredAt = updateredAt;
            Status = status;
            PurchaseItems = purchaseItems;
        }

        public int Id { get; private set; }
        public string Description { get; private set; }
        public string DeliveryAdress { get; private set; }
        public DateTime RegisteredAt { get; private set; }
        public DateTime UpdateredAt { get; private set; }
        public string Status { get; private set; }
        public List<PurchaseItemViewModel> PurchaseItems { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTesteInovage.Application.Models
{
    public class PurchaseViewModel
    {
        public PurchaseViewModel(int id, string description, string deliveryAdress)
        {
            Id = id;
            Description = description;
            DeliveryAdress = deliveryAdress;
        }

        public int Id { get; private set; }
        public string Description { get; private set; }
        public string DeliveryAdress { get; private set; }
    }
}

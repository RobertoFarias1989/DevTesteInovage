using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTesteInovage.Core.Entities
{
    public class PurchaseItem : BaseEntity
    {
        public PurchaseItem(int orderedQuantity, decimal totalPrice, int idPurchase, int idProduct)
        {
            OrderedQuantity = orderedQuantity;
            TotalPrice = totalPrice;
            IdPurchase = idPurchase;            
            IdProduct = idProduct;
        }

        public int OrderedQuantity { get; private set; }
        public decimal TotalPrice { get; private set; }
        public int IdPurchase { get; private set; }
        public Purchase Purchase { get; set; }
        public int IdProduct { get; private set; }
        public Product  Product{ get; private set; }

        public void Update(int orderedQuantity, decimal totalPrice)
        {
            OrderedQuantity = orderedQuantity;
            TotalPrice = totalPrice;
        }
    }
}

namespace DevTesteInovage.Application.Models
{
    public class UpdatePurchaseItemInputModel
    {
        public int Id { get; set; }
        public int OrderedQuantity { get;  set; }
        public decimal TotalPrice { get;  set; }
    }
}

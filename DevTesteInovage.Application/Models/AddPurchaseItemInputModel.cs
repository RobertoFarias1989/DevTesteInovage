namespace DevTesteInovage.Application.Models
{
    public class AddPurchaseItemInputModel
    {
        public int Id { get; set; }
        public int OrderedQuantity { get;  set; }
        public decimal TotalPrice { get;  set; }
        public int IdPurchase { get;  set; }
        public int IdProduct { get;  set; }
    }
}

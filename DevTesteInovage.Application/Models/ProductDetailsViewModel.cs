namespace DevTesteInovage.Application.Models
{
    public class ProductDetailsViewModel
    {
        public ProductDetailsViewModel(int id, 
            string title, 
            string description, 
            decimal price, 
            DateTime registeredAt, 
            List<PurchaseItemViewModel> purchaseItems,
            bool active)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            RegisteredAt = registeredAt;
            PurchaseItems = purchaseItems;
            Active = active;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public bool Active { get; private set; }
        public DateTime RegisteredAt { get; private set; }
        public List<PurchaseItemViewModel> PurchaseItems { get; private set; }
    }
}

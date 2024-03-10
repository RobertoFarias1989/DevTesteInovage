namespace DevTesteInovage.Core.Entities
{
    public class Product : BaseEntity
    {
        public Product(string title, string description, decimal price)
        {
            Title = title;
            Description = description;
            Price = price;

            Active = true;
            RegisteredAt = DateTime.Now;
            PurchaseItems = new List<PurchaseItem>();
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public bool Active { get; private set; }
        public DateTime RegisteredAt { get; private set; }
        public List<PurchaseItem> PurchaseItems{ get; private set; }

        public void Update(string description, decimal price)
        {
            Description = description;
            Price = price;
        }

        public void Inactived()
        {
            if(Active == true)
                Active = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTesteInovage.Application.Models
{
    public class ProductViewModel
    {
        public ProductViewModel(int id, string title, decimal price, bool active)
        {
            Id = id;
            Title = title;
            Price = price;
            Active = active;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public decimal Price { get; private set; }
        public bool Active { get; private set; }
    }
}

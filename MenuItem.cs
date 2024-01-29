using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace тортики
{
    internal class MenuItem
    {
    public string Description { get; set; }
        public decimal Price { get; set; }

        public MenuItem(string description, decimal price)
        {
            this.Description = description;
            this.Price = price;
        }
    }
}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingImplementation.Core
{
    public class Order
    {  
        public string UserId { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();

        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
    }
}

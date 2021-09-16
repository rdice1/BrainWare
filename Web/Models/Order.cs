using System;
using System.Collections.Generic;

namespace Web.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Description { get; set; }
        //public Dictionary<int, int> ProductOccurencesWithinOrder { get; set; }

        public List<Company> OrderCompany;
        public List<Product> OrderProducts;
    }
}

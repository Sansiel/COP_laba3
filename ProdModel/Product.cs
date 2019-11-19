using System;
using System.ComponentModel.DataAnnotations;

namespace ProdModel
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }
        public string ProductUnit { get; set; }
        public int ProductAmount { get; set; }
        public DateTime ProductData { get; set; }

    }
}

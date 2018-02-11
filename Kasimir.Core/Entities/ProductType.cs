using Kasimir.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kasimir.Core.Entities
{
    public class ProductType : IEntity
    {
        [Required, MaxLength(1)]
        public string Status { get; set; }
        [Required, MaxLength(50)]
        public string Number { get; set; }
        [Required, MaxLength(255)]
        public string Name { get; set; }
        public double GrossPrice { get; set; }
        public double NetPrice { get; set; }
        public string Barcode { get; set; }
        public ICollection<Product> ProductTypes2Products { get; set; }
        [NotMapped]
        public bool IsActive
        {
            get { return Status == "A"; }
            set { Status = value ? "A" : "I"; } 
        }
        public ProductType()
        {
            ProductTypes2Products = new List<Product>();
        }
    }
}

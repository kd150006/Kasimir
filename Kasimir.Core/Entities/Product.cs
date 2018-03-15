using Kasimir.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kasimir.Core.Entities
{
    public class Product : IEntity
    {
        [Required, MaxLength(1)]
        public string Status { get; set; }
        [Required, MaxLength(50)]
        public string Number { get; set; }
        [Required, MaxLength(255)]
        public string Name { get; set; }        
        public double NetPrice { get; set; }
        public string Barcode { get; set; }
        public int? StockId { get; set; }
        [ForeignKey(nameof(StockId))]
        public Stock Stock { get; set; }
        public int? Quantity { get; set; }        

        public Product()
        {                        
        }
    }
}

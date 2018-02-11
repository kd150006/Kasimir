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
        public int StockId { get; set; }
        [Required]
        [ForeignKey(nameof(StockId))]
        public Stock Stock { get; set; }        
        public int ProductTypeId { get; set; }
        [Required]
        [ForeignKey(nameof(ProductTypeId))]
        public ProductType ProductType { get; set; }
        [Required, MaxLength(1)]
        public string Status { get; set; }
        public string SerialNumber { get; set; }
    }
}

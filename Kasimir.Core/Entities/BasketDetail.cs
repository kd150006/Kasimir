using Kasimir.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kasimir.Core.Entities
{
    public class BasketDetail : IEntity
    {
        public int BasketHeaderId { get; set; }
        [Required]
        [ForeignKey(nameof(BasketHeaderId))]
        public BasketHeader BasketHeader { get; set; }
        public int ProductId { get; set; }
        [Required]
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public double ProductPrice { get; set; }
        public string ProductSerialNumber { get; set; }
        public int? StockId { get; set; }
        [ForeignKey(nameof(StockId))]
        public Stock Stock { get; set; }
    }
}

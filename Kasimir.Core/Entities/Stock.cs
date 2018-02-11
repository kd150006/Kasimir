using Kasimir.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kasimir.Core.Entities
{
    public class Stock : IEntity
    {
        [Required, MaxLength(1)]
        public string Status { get; set; }
        [Required, MaxLength(255)]
        public string Name { get; set; }
        public int Quantity { get; set; }
        [NotMapped]
        public bool IsActive
        {
            get { return Status == "A"; }
            set { Status = value ? "A" : "I"; }
        }
        public ICollection<Product> Stocks2Products { get; set; }
        public Stock()
        {
            Stocks2Products = new List<Product>();
        }
    }
}

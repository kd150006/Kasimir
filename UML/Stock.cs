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
        //Quantity will be calculated by amount of rows in entity 'Product' ?
        //public int Quantity { get; set; }
        [NotMapped]
        public bool IsActive
        {
            get { return Status == ItemStatus.Active; }
            set { Status = value ? ItemStatus.Active : ItemStatus.Inactive; }
        }
        public ICollection<Product> Stocks2Products { get; set; }
        public Stock()
        {
            Stocks2Products = new List<Product>();
        }
    }
}

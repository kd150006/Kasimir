using Kasimir.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kasimir.Core.Entities
{
    public class BasketHeader : IEntity
    {        
        [Required]
        public DateTime BasketDate { get; set; }
        public double SumTotal { get; set; }
        public int ReferenceBasketHeaderId { get; set; }
        [Required]
        public string TransactionType { get; set; }
        [Required]
        public ICollection<BasketDetail> BasketDetails { get; set; }
        public BasketHeader()
        {
            BasketDetails = new List<BasketDetail>();
        }
    }
}

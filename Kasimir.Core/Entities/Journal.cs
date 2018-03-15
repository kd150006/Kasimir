using Kasimir.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kasimir.Core.Entities
{
    public class Journal: IEntity
    {
        [Required]
        public DateTime DateOfTransaction { get; set; }
        [Required, MaxLength(1)]
        public string  TransactionType { get; set; }
        public int BasketHeaderId { get; set; }
        [ForeignKey(nameof(BasketHeaderId))]
        public BasketHeader BasketHeader { get; set; }

    }
}

using Kasimir.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kasimir.Core.Entities
{
    public class CashDrawer : IEntity
    {
        [Required, MaxLength(255)]
        public string Name { get; set; }
        [Required, MaxLength(1)]
        //IMPROVEMENT: Add validation so that Status is only of type ITEMSTATUS
        public string Status { get; set; }
        public double Amount { get; set; }
        public int? MeansOfPaymentId { get; set; }
        [ForeignKey(nameof(MeansOfPaymentId))]
        public MeansOfPayment MeansOfPayment { get; set; }
    }
}

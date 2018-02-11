using Kasimir.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kasimir.Core.Entities
{
    public class MeansOfPayment : IEntity
    {
        [Required, MaxLength(255)]
        public string Name { get; set; }
        [Required, MaxLength(1)]        
        public string Status { get; set; }
    }
}

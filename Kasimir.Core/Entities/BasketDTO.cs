using Kasimir.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kasimir.Core.Entities
{
    public class BasketDTO
    {
        public DateTime BasketDate { get; set; }
        public double SumTotal { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}

using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kasimir.Core.DataTransferObjects
{
    [NotMapped]
    public class BasketDto
    {
        //Foreign Keys       
        public int? StockId { get; set; }        
        public string StockName { get; set; }
        public int? SerialNumberId { get; set; }
        public string SerialNumberText { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductNumber { get; set; }
        public double ProductPrice { get; set; }
        //public List<SerialNumber> SerialNumbers { get; set; }
    }
}

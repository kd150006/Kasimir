using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kasimir.Core.DataTransferObjects
{
    [NotMapped]
    public class BasketDto
    {        
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }       
        public string ProductSerialNumber { get; set; }
        public string ProductStock { get; set; }
        public double ProductPrice { get; set; }
        public string ProductStatus { get; set; }
        public string TransactionType { get; set; }        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kasimir.WebAPI.DTOs
{
    public class ProductTypes2ProductDto
    {
        public string ProductTypeNumber { get; set; }
        public string ProductTypeName { get; set; }
        public string ProductTypeBarcode { get; set; }
        public double ProductTypeGrossPrice { get; set; }
        public double ProductTypeNetPrice { get; set; }
        public string ProductTypeStatus { get; set; }
        public string ProductSerialNumber { get; set; }
        public string ProductStock { get; set; }
        public string ProductStatus { get; set; }
        public int ProductId { get; set; }
        public int ProductTypeId { get; set; }
    }
}

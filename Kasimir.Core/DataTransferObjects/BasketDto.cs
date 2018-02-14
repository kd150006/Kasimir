using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kasimir.Core.DataTransferObjects
{
    [NotMapped]
    public class BasketDto
    {
        //ProductType: Name, Nummer, Status
        //Product: SerialNumber, Status?
        //Stock: Name

        // Alle 3 FKs laden 
        public string ProductTypeName { get; set; }
        public string ProductTypeNumber { get; set; }
        public string ProductSerialNumber { get; set; }
        public string StockName { get; set; }
    }
}

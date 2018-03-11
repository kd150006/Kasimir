using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kasimir.WebAPI.DataTransferObjects
{
    public class BasketDto
    {
        //BasketHeader?
        //BasketDetail?
        //Stocks
        //Products
        #region ForeignKeys
        public int? StockId { get; set; }
        public int? SerialNumberId { get; set; }
        public int ProductId { get; set; }
        #endregion
        public string ProductName { get; set; }
        public string ProductNumber { get; set; }
        public double ProductPrice { get; set; }
        public string StockName { get; set; }        
        public string SerialNumberText { get; set; }
    }
}

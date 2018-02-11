using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kasimir.Web.Admin.ViewModels
{
    public class StockViewModel
    {
        public Stock[] Stocks { get; set; }
        public bool IsActive { get; set; }
        public StockViewModel()
        {

        }
        public StockViewModel(Stock[] stocks)
        {
            Stocks = stocks;
        }
    }
}

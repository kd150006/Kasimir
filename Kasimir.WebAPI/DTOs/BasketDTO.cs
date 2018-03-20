using Kasimir.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kasimir.Core.Entities
{
    public class Basket
    {

        public BasketHeader BasketHeader { get; set; }

        public Basket(BasketDTO basket)
        {
            ConvertBasketDTOToBasketHeaderAndBasketDetails(basket);
        }

        private void ConvertBasketDTOToBasketHeaderAndBasketDetails(BasketDTO basket)
        {
            var basketDetails = basket.
                Products
                .Select(p => new BasketDetail
                {
                    Product = p,
                    // TODO hardcoded qty
                    Quantity = 1,
                    ProductPrice = p.NetPrice
                })
                .ToList();
            
            BasketHeader = new BasketHeader { BasketDate = basket.BasketDate, SumTotal = basket.SumTotal, BasketDetails = basketDetails  };
        }
    }
}

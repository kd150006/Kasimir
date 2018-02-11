using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kasimir.Core
{
    public class ImportController
    {
        public static IEnumerable<ProductType> ReadProductTypesFromCsv()
        {
            //General options
            var matrix = MyFileUtils.MyFileUtils.ReadStringMatrixFromCsv("Articles.csv", true);

            //Stocks
            var stocks = matrix
                .Where(line => line[7] != String.Empty)
                .GroupBy(line => line[7])
                .Select(groupedLine => new Stock
                {
                    Name = groupedLine.Key,
                    Status = "A",
                })
                .ToList();
            //ProductTypes
            var productTypes = matrix
                .Select(line => new ProductType
                {
                    Barcode = line[5],
                    Status = "A",
                    Number = line[0],
                    Name = line[1],                    
                })
                .ToList();
            //Products
            var products = matrix
                .Where(line => line[6] != String.Empty)
                .Select(line => new Product
                {
                    SerialNumber = line[6],
                    Status ="A",
                    ProductType = productTypes.Single(productType => productType.Name == line[1]),
                    Stock = stocks.Single(stock => stock.Name == line[7])
                })
                .ToList();
       
            foreach (var product in products)
            {
                productTypes.SingleOrDefault(pt => pt.Number == product.ProductType.Number).ProductTypes2Products.Add(product);
                stocks.Single(stock => stock.Name == product.Stock.Name).Stocks2Products.Add(product);
            }

            return productTypes;
        }
    }
}
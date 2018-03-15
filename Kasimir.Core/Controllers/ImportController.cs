using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kasimir.Core
{
    public class ImportController
    {
        public static IEnumerable<Product> ReadProductsFromCsv()
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
                    Status = "A"
                })
                .ToList();

            //Products
            var products = matrix
                .Select(line => new Product
                {
                    Number = line[0],
                    Name = line[1],
                    Barcode = line[5],
                    Stock = stocks.Where(stock => stock.Name.Equals(line[7])).SingleOrDefault(),
                    //Quantity = Convert.ToInt32(line[8]),
                    Status = "A"
                })
                .ToList();

            //SerialNumbers
            //var serialNumbers = matrix
            //    .Where(line => line[6] != String.Empty)
            //    .Select(foundLine => new SerialNumber
            //    {
            //        SerialNumberText = foundLine[6],
            //        Product = products.Where(product => product.Number.Equals(foundLine[0])).Single(),
            //        Status = "A"
            //    })
            //    .ToList();            

            //foreach (var product in products)
            //{
            //    product.SerialNumbers.Add(serialNumbers
            //                                .Where(serialNumber => serialNumber.Product.Name.Equals(product.Name))                                            
            //                                .SingleOrDefault()
            //                            );
            //}

            return products;
        }
    }
}
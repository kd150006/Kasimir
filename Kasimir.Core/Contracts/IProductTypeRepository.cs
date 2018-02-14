using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kasimir.Core.Contracts
{
    public interface IProductTypeRepository
    {
        void AddRange(List<ProductType> productTypes);
        void Add(ProductType productType);
        void Delete(ProductType productType);
        void Update(ProductType productType);
        IEnumerable<ProductType> GetAll();
        IEnumerable<ProductType> GetAllByStatus(string status);
        IEnumerable<ProductType> GetById(int id);
        IEnumerable<ProductType> GetByNumber(string number);
        IEnumerable<ProductType> GetByName(string name);
        IEnumerable<ProductType> GetByBarcode(string barcode);
        IEnumerable<ProductType> GetByStatus(string status);
        IEnumerable<ProductType> GetAllWithProductsAndStocks();
        ProductType GetByIdWithProducts(int id);
        ProductType GetByIdWithProductsAndStocks(int id);
    }
}

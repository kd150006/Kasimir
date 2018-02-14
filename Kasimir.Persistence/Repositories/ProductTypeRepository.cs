using Kasimir.Core;
using Kasimir.Core.Contracts;
using Kasimir.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kasimir.Persistence.Repositories
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductTypeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void ActivateProductType(IEnumerable<ProductType> productTypes)
        {
            foreach (var productType in productTypes)
            {
                productType.Status = ItemStatus.Active;
            }
        }

        public void Add(ProductType productType)
        {
            _dbContext.Add(productType);
        }

        public void AddRange(List<ProductType> productTypes)
        {
            _dbContext.AddRange(productTypes);
        }

        public void Delete(ProductType productType)
        {
            productType.Status = ItemStatus.Deleted;
            Update(productType);            
        }

        public IEnumerable<ProductType> GetAll()
        {
            return _dbContext.ProductTypes.Where(productType => productType.Status != ItemStatus.Deleted);
        }

        public IEnumerable<ProductType> GetAllByStatus(string status)
        {
            return _dbContext.ProductTypes.Where(productType => productType.Status == status);
        }

        public IEnumerable<ProductType> GetAllWithProductsAndStocks()
        {
            return _dbContext.ProductTypes
                .Include(productTypes => productTypes.ProductTypes2Products)
                    .ThenInclude(productTypesWithProducts => productTypesWithProducts.Stock)
                .ToList();
        }

        public IEnumerable<ProductType> GetByBarcode(string barcode)
        {
            return _dbContext.ProductTypes.Where(productType => productType.Barcode == barcode);
        }

        public IEnumerable<ProductType> GetById(int id)
        {
            return _dbContext.ProductTypes.Where(productType => productType.Id == id);
        }

        public ProductType GetByIdWithProducts(int id)
        {
            return _dbContext.ProductTypes
                .Where(productType => productType.Id == id)
                .Include(foundProductType => foundProductType.ProductTypes2Products)                
                .SingleOrDefault();
        }

        public ProductType GetByIdWithProductsAndStocks(int id)
        {
            return _dbContext.ProductTypes
                .Include(productType => productType.ProductTypes2Products)
                    .ThenInclude(productTypeWithProducts => productTypeWithProducts.Stock)
                .Where(productType => productType.Id == id)
                .SingleOrDefault();                
        }

        public IEnumerable<ProductType> GetByName(string name)
        {
            return _dbContext.ProductTypes.Where(productType => productType.Name == name);
        }

        public IEnumerable<ProductType> GetByNumber(string number)
        {
            return _dbContext.ProductTypes.Where(productType => productType.Number == number);
        }

        public IEnumerable<ProductType> GetByStatus(string status)
        {
            return _dbContext.ProductTypes.Where(productType => productType.Status == status);
        }

        public void Update(ProductType productType)
        {
            _dbContext.Update(productType);
        }
    }
}

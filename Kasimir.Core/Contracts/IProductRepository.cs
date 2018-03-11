using Kasimir.Core.DataTransferObjects;
using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kasimir.Core.Contracts
{
    public interface IProductRepository
    {
        void AddRange(List<Product> products);
        void Add(Product product);
        void Delete(Product product);
        void Update(Product product);
        Product GetById(int id);
        IEnumerable<Product> GetByName(string name);
        IEnumerable<Product> GetByNumber(string number);
        IEnumerable<Product> GetAll();
    }
}

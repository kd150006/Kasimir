using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Kasimir.Core.Contracts;
using Kasimir.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Kasimir.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/ProductTypes")]
    public class ProductTypesController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public ProductTypesController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET producttypes/
        [HttpGet]
        public IEnumerable<ProductType> Get()
        {
            var products = _uow.ProductTypeRepository.GetAllWithProductsAndStocks();
            //var products = _uow.ProductTypeRepository.GetAll();
            return (products);
        }

        // GET producttypes/7
        [HttpGet("{id}")]
        public ProductType Get(int id)
        {
            //var productType = _uow.ProductTypeRepository.GetById(id).SingleOrDefault();
            var productType = _uow.ProductTypeRepository.GetByIdWithProducts(id);
            return productType;
        }

        // POST producttype
        [HttpPost]
        public void Post([FromBody]ProductType productType)
        {
            _uow.ProductTypeRepository.Add(productType);
            _uow.Save();

        }

        // PUT producttypes/7
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]ProductType productType)
        {
            ProductType productTypeToUpdate = _uow.ProductTypeRepository.GetById(id).SingleOrDefault();
            _uow.ProductTypeRepository.Update(productTypeToUpdate);
            _uow.Save();
        }

        // DELETE producttypes/7
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var productType = _uow.ProductTypeRepository.GetById(id).SingleOrDefault();
            _uow.ProductTypeRepository.Delete(productType);
            _uow.Save();
        }

    }
}

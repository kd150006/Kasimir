using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kasimir.Core;
using Kasimir.Core.Contracts;
using Kasimir.WebAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kasimir.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/ProductTypes2Products")]
    public class ProductTypes2ProductsController : Controller
    {
        private readonly IUnitOfWork _uow;
        public ProductTypes2ProductsController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: api/ProductTypes2Products
        [HttpGet]
        public IEnumerable<ProductTypes2ProductDto> Get()
        {
            //IMPROVEMENT Load only those products in status "A"
            //IMPROVEMENT Think of a better way for population the Dtos. Maybe in Core?
            List<ProductTypes2ProductDto> resultList = new List<ProductTypes2ProductDto>();
            var productTypes2ProductsDtos = _uow.ProductTypeRepository
                .GetAllWithProducts();                
            foreach (var item in productTypes2ProductsDtos)
            {
                ProductTypes2ProductDto dto = new ProductTypes2ProductDto();
                dto.ProductSerialNumber = item.ProductTypes2Products.Select(i => i.SerialNumber).SingleOrDefault();
                dto.ProductStatus = item.ProductTypes2Products.Select(i => i.Status).SingleOrDefault();
                //dto.ProductStock = item.ProductTypes2Products.Select(i => i.Stock.Name).SingleOrDefault();
                dto.ProductTypeBarcode = item.Barcode;
                dto.ProductTypeGrossPrice = item.GrossPrice;
                dto.ProductTypeName = item.Name;
                dto.ProductTypeNetPrice = item.NetPrice;
                dto.ProductTypeNumber = item.Number;
                dto.ProductTypeStatus = item.Status;
                dto.ProductTypeId = item.Id;
                dto.ProductId = item.ProductTypes2Products.Select(i => i.Id).SingleOrDefault();
                resultList.Add(dto);
            }
            resultList.OrderBy(item => item.ProductTypeName);
            return (resultList);
        }

        // GET: api/ProductTypes2Products/5
        [HttpGet("{id}")]
        public ProductTypes2ProductDto Get(int id)
        {
            var prdouctType2product = _uow.ProductTypeRepository.GetByIdWithProducts(id);
            ProductTypes2ProductDto dto = new ProductTypes2ProductDto();
            dto.ProductSerialNumber = prdouctType2product.ProductTypes2Products.Select(i => i.SerialNumber).SingleOrDefault();
            dto.ProductStatus = prdouctType2product.ProductTypes2Products.Select(i => i.Status).SingleOrDefault();
            dto.ProductStock = prdouctType2product.ProductTypes2Products.Select(i => i.Stock.Name).SingleOrDefault();
            dto.ProductTypeBarcode = prdouctType2product.Barcode;
            dto.ProductTypeGrossPrice = prdouctType2product.GrossPrice;
            dto.ProductTypeName = prdouctType2product.Name;
            dto.ProductTypeNetPrice = prdouctType2product.NetPrice;
            dto.ProductTypeNumber = prdouctType2product.Number;
            dto.ProductTypeStatus = prdouctType2product.Status;
            dto.ProductTypeId = prdouctType2product.Id;
            dto.ProductId = prdouctType2product.ProductTypes2Products.Select(i => i.Id).SingleOrDefault();
            return (dto);

        }
        
        // POST: api/ProductTypes2Products
        [HttpPost]
        public void Post([FromBody]string value)
        {
            throw new NotImplementedException();
        }
        
        // PUT: api/ProductTypes2Products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

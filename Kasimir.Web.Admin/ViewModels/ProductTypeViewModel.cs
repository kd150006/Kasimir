using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kasimir.Web.Admin.ViewModels
{
    public class ProductTypeViewModel
    {
        public ProductType[] ProductTypes { get; set; }
        public bool IsActive { get; set; }
        public ProductTypeViewModel()
        {           
        }
        public ProductTypeViewModel(ProductType[] productTypes)
        {
            ProductTypes = productTypes;           
        }
    }
}

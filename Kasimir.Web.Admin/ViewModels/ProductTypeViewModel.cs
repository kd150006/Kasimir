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
        public Product[] ProductTypes { get; set; }
        public bool IsActive { get; set; }
        public ProductTypeViewModel()
        {           
        }
        public ProductTypeViewModel(Product[] productTypes)
        {
            ProductTypes = productTypes;           
        }
    }
}

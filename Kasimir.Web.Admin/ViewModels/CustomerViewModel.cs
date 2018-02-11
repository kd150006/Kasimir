using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kasimir.Web.Admin.ViewModels
{
    public class CustomerViewModel
    {
        public Customer[] Customers { get; set; }
        public bool IsActive { get; set; }
        public CustomerViewModel()
        {

        }
        public CustomerViewModel(Customer[] customers)
        {
            Customers = customers;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kasimir.Core
{
    [NotMapped]
    public static class ProductStatus
    {
        public const string Available = "A";
        public const string Sold = "S";
    }
}

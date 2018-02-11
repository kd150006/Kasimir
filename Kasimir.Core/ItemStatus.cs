using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kasimir.Core
{
    [NotMapped]
    public static class ItemStatus
    {
        public const string Active = "A";
        public const string Inactive = "I";
        public const string Deleted = "D";
        public const string System = "S";
    }
}

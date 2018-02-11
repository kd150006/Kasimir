using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kasimir.Core
{
    [NotMapped]
    public static class TransactionType
    {
        public const string Purchase = "P";
        public const string Return = "R";
        public const string Exchange = "E";
        public const string Cancellation = "C";
        public const string System = "S";
    }
}

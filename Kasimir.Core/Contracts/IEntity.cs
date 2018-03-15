using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kasimir.Core.Contracts
{
    public class IEntity
    {
        [Key]
        public int Id { get; set; }
        //MySql needs to have rowversion to be of DateTime instead of byte[]
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}

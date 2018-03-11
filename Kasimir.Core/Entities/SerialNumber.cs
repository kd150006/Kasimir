using Kasimir.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kasimir.Core.Entities
{
    public class SerialNumber : IEntity
    {
        [Required]
        public string SerialNumberText { get; set; }
        [Required, MaxLength(1)]
        public string Status { get; set; }
        public int ProductId { get; set; }
        [Required]
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        [NotMapped]
        public bool IsActive
        {
            get { return Status == ItemStatus.Active; }
            set { Status = value ? ItemStatus.Active : ItemStatus.Inactive; }
        }
    }
}

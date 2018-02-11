using Kasimir.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kasimir.Core.Entities
{
    public class Customer : IEntity
    {

        [Required, MaxLength(1)]
        public string Status { get; set; }
        [Required, MaxLength(255)]
        public string FirstName { get; set; }
        [Required, MaxLength(255)]
        public string LastName { get; set; }
        [Required, MaxLength(255)]
        public string Number { get; set; }        
        public int? TelephoneNumber { get; set; }
        public string EmailAddress { get; set; }
        [NotMapped]
        public bool IsActive
        {
            get { return Status == "A"; }
            set { Status = value ? "A" : "I"; }
        }
    }
}

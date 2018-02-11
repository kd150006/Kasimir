using Kasimir.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kasimir.Core.Entities
{
    public class User : IEntity
    {
        [Required, MaxLength(1)]
        public string Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        //IMPROVEMENT: Encrypt password 
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}

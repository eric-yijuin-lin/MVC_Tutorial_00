using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Tutorial_00.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}

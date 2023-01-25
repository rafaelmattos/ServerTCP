using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Server.Models
{
    
    public class UserCliente
    {
        
        public virtual AppUser User { get; set; }
        [Key]
        public string UserId { get; set; }
        public virtual Cliente Cliente { get; set; }
        [Key]
        public int ClienteId { get; set; }

    }
}

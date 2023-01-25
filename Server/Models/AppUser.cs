using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;


namespace Server.Models
{
    public class AppUser:IdentityUser
    {
        public AppUser()
        {
            UserClientes = new HashSet<UserCliente>();
        }
        public string Nome { get; set; }        
        public virtual ICollection<UserCliente> UserClientes { get; set; }
    }
}

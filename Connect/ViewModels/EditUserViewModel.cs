using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Connect.ViewModels
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Claims = new List<string>();
            Roles = new List<string>();
            Clientes = new List<string>();
        }

        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]       
        public string Nome { get; set; }
        

        public List<string> Claims { get; set; }

        public IList<string> Roles { get; set; }
        public IList<string> Clientes { get; set; }
    }
}

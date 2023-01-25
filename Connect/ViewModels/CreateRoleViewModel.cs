using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Connect.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Perfil")]
        public string RoleName { get; set; }
    }
}

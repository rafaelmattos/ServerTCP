using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Server
{
    public class Linguagens
    {
        [Key]
        public string En {get; set;}
        public string Pt { get; set; }       
        
    }
}

using Server.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Cliente
    {
        public Cliente()
        {
            UsersCliente = new HashSet<UserCliente>();

        }

        
        public int Id { get; set; }
        [Display(Name = "Apelido")]
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string Endereco { get; set; }


        public virtual Cliente ClientePai { get; set; }
        public int? ClientePaiId { get; set; }
        public List<Cliente> Clientes { get; set; }

        public List<Equipamento> Equipamentos { get; set; }
        public virtual ICollection<UserCliente> UsersCliente { get; set; }
    }
}

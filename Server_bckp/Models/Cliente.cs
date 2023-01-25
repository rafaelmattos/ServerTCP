using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public List<Equipamento> Equipamentos { get; set; }
    }
}

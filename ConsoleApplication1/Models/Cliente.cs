using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public List<Equipamento> Equipamentos { get; set; }
    }
}

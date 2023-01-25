using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Equipamento
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        
        public virtual Cliente Cliente { get; set; }
        public int ClienteId { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double Saldo { get; set; }

        public void AdicionarSaldo(double valor)
        {
            this.Saldo += valor;
        }

        public void RetirarSaldo(double valor)
        {
            this.Saldo -= valor;
        }
    }
}

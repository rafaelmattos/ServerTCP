using ConsoleApplication1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApplication1.Models.ViewModels
{
    public class TransacoesViewModel
    {
        public Cliente Cliente { get; set; }
        public Equipamento Equipamento { get; set; }
        public List<RemoteMessage>  Transacoes { get; set; }

    }
}

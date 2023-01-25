using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models.ViewModels
{
    public class TransacoesViewModel
    {
        public Cliente Cliente { get; set; }
        public Equipamento Equipamento { get; set; }
        public List<RemoteMessage>  Transacoes { get; set; }

    }
}

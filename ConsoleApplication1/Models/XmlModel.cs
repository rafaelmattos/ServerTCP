using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ConsoleApplication1.Models
{
    public class XmlModel
    {
        [Key]
        public int Id { get; set; }

        [XmlText]
        public string Conteudo { get; set; }

        public DateTime DataRecebimento { get; set; }

        public int Status { get; set; }


    }
}

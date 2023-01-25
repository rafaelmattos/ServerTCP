using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Server
{
    [XmlRoot(ElementName = "countings")]
	public class Countings
	{
		public int Id { get; set; }

		[XmlElement(ElementName = "category")]
		public List<Category> Category { get; set; }

		[XmlAttribute(AttributeName = "valid")]
		public int Valid { get; set; }

		[XmlElement(ElementName = "counted")]
		public List<Counted> Counted { get; set; }

		[Display(Name = "Número de Cédulas")]
		public int QtdCedulas
		{
			get { return this.Counted.Sum(item => item.Quantity); }
		}
	}


}

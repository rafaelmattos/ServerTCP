using System.Collections.Generic;
using System.Xml.Serialization;

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
	}


}

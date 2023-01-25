using System.Xml.Serialization;

namespace Server
{
    [XmlRoot(ElementName = "model")]
	public class Model
	{
		public int Id { get; set; }

		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }

		[XmlAttribute(AttributeName = "sn")]
		public string Sn { get; set; }
	}


}

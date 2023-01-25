using System.Xml.Serialization;

namespace Server
{
    [XmlRoot(ElementName = "bagsConfig")]
	public class BagsConfig
	{
		public int Id { get; set; }

		[XmlElement(ElementName = "bag")]
		public Bag Bag { get; set; }
	}


}

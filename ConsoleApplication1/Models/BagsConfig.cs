using System.Xml.Serialization;

namespace ConsoleApplication1
{
    [XmlRoot(ElementName = "bagsConfig")]
	public class BagsConfig
	{
		public int Id { get; set; }

		[XmlElement(ElementName = "bag")]
		public Bag Bag { get; set; }
	}


}

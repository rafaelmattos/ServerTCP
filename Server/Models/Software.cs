using System.Xml.Serialization;

namespace Server
{
    [XmlRoot(ElementName = "software")]
	public class Software
	{
		public int Id { get; set; }
		[XmlElement(ElementName = "sw")]
		public Sw Sw { get; set; }
	}


}

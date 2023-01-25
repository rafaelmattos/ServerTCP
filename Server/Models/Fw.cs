using System.Xml.Serialization;

namespace Server
{
    [XmlRoot(ElementName = "fw")]
	public class Fw
	{
		public int Id { get; set; }
		[XmlAttribute(AttributeName = "version")]
		public string Version { get; set; }
	}


}

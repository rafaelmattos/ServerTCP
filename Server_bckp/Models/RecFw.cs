using System.Xml.Serialization;

namespace Server
{
    [XmlRoot(ElementName = "RecFw")]
	public class RecFw
	{
		public int Id { get; set; }

		[XmlAttribute(AttributeName = "version")]
		public string Version { get; set; }
	}


}

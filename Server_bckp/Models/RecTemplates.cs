using System.Xml.Serialization;

namespace Server
{
    [XmlRoot(ElementName = "RecTemplates")]
	public class RecTemplates
	{
		public int Id { get; set; }

		[XmlElement(ElementName = "Template")]
		public string Template { get; set; }
	}


}

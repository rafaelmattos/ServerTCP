using System.Xml.Serialization;

namespace Server
{
    [XmlRoot(ElementName = "category")]
	public class Category
	{
		public int Id { get; set; }

		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }

		[XmlAttribute(AttributeName = "nDoc")]
		public int NDoc { get; set; }

		[XmlAttribute(AttributeName = "amount")]
		public int Amount { get; set; }
	}


}

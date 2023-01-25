using System.Xml.Serialization;

namespace ConsoleApplication1
{
    [XmlRoot(ElementName = "denom")]
	public class Denom
	{
		public int Id { get; set; }

		[XmlAttribute(AttributeName = "curr")]
		public string Curr { get; set; }

		[XmlAttribute(AttributeName = "value")]
		public int Value { get; set; }
	}


}

using System.Xml.Serialization;

namespace Server
{
    [XmlRoot(ElementName = "stock")]
	public class Stock
	{

		[XmlElement(ElementName = "denom")]
		public Denom Denom { get; set; }

		[XmlAttribute(AttributeName = "id")]
		public int Id { get; set; }

		[XmlAttribute(AttributeName = "recycle")]
		public bool Recycle { get; set; }

		[XmlAttribute(AttributeName = "L2")]
		public bool L2 { get; set; }

		[XmlAttribute(AttributeName = "L3")]
		public bool L3 { get; set; }

		[XmlAttribute(AttributeName = "L4B")]
		public bool L4B { get; set; }

		[XmlAttribute(AttributeName = "exceedings")]
		public bool Exceedings { get; set; }
	}


}

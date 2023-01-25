using System.Xml.Serialization;

namespace Server
{
    [XmlRoot(ElementName = "Total")]
	public class Total
	{
		public int Id { get; set; }

		[XmlAttribute(AttributeName = "currency")]
		public string Currency { get; set; }

		[XmlAttribute(AttributeName = "amount")]
		public int Amount { get; set; }
	}


}

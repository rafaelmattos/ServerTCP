using System.Xml.Serialization;

namespace Server
{
    [XmlRoot(ElementName = "CashIn")]
	public class CashIn
	{
		public int Id { get; set; }

		[XmlElement(ElementName = "Amount")]
		public Amount Amount { get; set; }
	}


}

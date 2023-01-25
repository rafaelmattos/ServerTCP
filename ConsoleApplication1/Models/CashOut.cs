using System.Xml.Serialization;

namespace ConsoleApplication1
{
    [XmlRoot(ElementName = "CashOut")]
	public class CashOut
	{
		public int Id { get; set; }

		[XmlElement(ElementName = "Amount")]
		public Amount Amount { get; set; }
	}


}

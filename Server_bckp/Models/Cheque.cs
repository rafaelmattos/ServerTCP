using System.Xml.Serialization;

namespace Server
{
    [XmlRoot(ElementName = "cheque")]
	public class Cheque
	{
		public int Id { get; set; }

		[XmlAttribute(AttributeName = "curr")]
		public string Curr { get; set; }

		[XmlAttribute(AttributeName = "codeline")]
		public string Codeline { get; set; }

		[XmlAttribute(AttributeName = "amount")]
		public int Amount { get; set; }
	}


}

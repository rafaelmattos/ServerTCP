using System.Xml.Serialization;

namespace ConsoleApplication1
{
    [XmlRoot(ElementName = "count")]
	public class Count
	{
		public int Id { get; set; }

		[XmlAttribute(AttributeName = "machineId")]
		public int MachineId { get; set; }

		[XmlAttribute(AttributeName = "den")]
		public double Den { get; set; }

		[XmlAttribute(AttributeName = "curr")]
		public string Curr { get; set; }

		[XmlAttribute(AttributeName = "qty")]
		public int Qty { get; set; }

		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }

		[XmlAttribute(AttributeName = "N")]
		public int N { get; set; }

		[XmlAttribute(AttributeName = "sType")]
		public string SType { get; set; }
	}


}

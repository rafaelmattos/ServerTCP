using System;
using System.Xml.Serialization;

namespace ConsoleApplication1
{
    [XmlRoot(ElementName = "manualDeposit")]
	public class ManualDeposit
	{
		public int Id { get; set; }

		[XmlElement(ElementName = "Total")]
		public Total Total { get; set; }

		[XmlAttribute(AttributeName = "nop")]
		public int Nop { get; set; }

		[XmlAttribute(AttributeName = "Date")]
		public DateTime Date { get; set; }

		[XmlAttribute(AttributeName = "Time")]
		public DateTime Time { get; set; }

		[XmlAttribute(AttributeName = "userId")]
		public int UserId { get; set; }

		[XmlAttribute(AttributeName = "envelopeId")]
		public int EnvelopeId { get; set; }
	}


}

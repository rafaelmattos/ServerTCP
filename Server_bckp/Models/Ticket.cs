using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server
{
    [XmlRoot(ElementName = "ticket")]
	public class Ticket
	{
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }

		[XmlAttribute(AttributeName = "barcode")]
		public string Barcode { get; set; }

		[XmlAttribute(AttributeName = "id")]
		public string TicketId { get; set; }

		[XmlAttribute(AttributeName = "curr")]
		public string Curr { get; set; }

		[XmlAttribute(AttributeName = "amount")]
		public int Amount { get; set; }

		[XmlAttribute(AttributeName = "qty")]
		public int Qty { get; set; }
	} 


}

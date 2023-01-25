using System.Collections.Generic;
using System.Xml.Serialization;

namespace ConsoleApplication1
{
    [XmlRoot(ElementName = "tickets")]
	public class Tickets
	{
		public int Id { get; set; }

		[XmlElement(ElementName = "ticket")]
		public List<Ticket> Ticket { get; set; }
	}


}

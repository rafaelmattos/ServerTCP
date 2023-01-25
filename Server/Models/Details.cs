using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Server
{
    [XmlRoot(ElementName = "Details")]
	public class Details
	{
		public int Id { get; set; }


		[DataType(DataType.Currency)]
		[XmlElement(ElementName = "total")]
		[DisplayFormat(DataFormatString = "{0:N}")]
		public double Total { get; set; }

		[XmlElement(ElementName = "countings")]
		public Countings Countings { get; set; }

		[XmlAttribute(AttributeName = "Currency")]
		[Display(Name = "Moeda")]
		public string Currency { get; set; }

		[XmlText]
		public string Text { get; set; }

		[XmlElement(ElementName = "Account")]
		public string Account { get; set; }
	}


}

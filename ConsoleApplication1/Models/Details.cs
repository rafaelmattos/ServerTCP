using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ConsoleApplication1
{
    [XmlRoot(ElementName = "Details")]
	public class Details
	{
		public int Id { get; set; }

		

		[XmlElement(ElementName = "total")]
		[DataType(DataType.Currency)]
		[DisplayFormat(DataFormatString = "{0:C2}")]
		public double Total { get; set; }

		[XmlElement(ElementName = "countings")]
		public Countings Countings { get; set; }

		[XmlAttribute(AttributeName = "Currency")]
		public string Currency { get; set; }

		[XmlText]
		public string Text { get; set; }

		[XmlElement(ElementName = "Account")]
		public string Account { get; set; }
	}


}

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Server
{
    [XmlRoot(ElementName = "counted")]
	public class Counted
	{
		public int Id { get; set; }

		[XmlAttribute(AttributeName = "denom")]
		[DataType(DataType.Currency)]
		[DisplayFormat(DataFormatString = "{0:C2}")]
		public double Denom { get; set; }

		[XmlAttribute(AttributeName = "quantity")]
		public int Quantity { get; set; }

		[XmlAttribute(AttributeName = "type")]
		public string Type { get; set; }

		[DataType(DataType.Currency)]
		[DisplayFormat(DataFormatString = "{0:C2}")]
		public double? SubTotal
		{
			get { return this.Denom * this.Quantity; }
		}
	}


}

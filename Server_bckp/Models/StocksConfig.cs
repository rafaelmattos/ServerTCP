using System.Collections.Generic;
using System.Xml.Serialization;

namespace Server
{
    [XmlRoot(ElementName = "stocksConfig")]
	public class StocksConfig
	{
		public int Id { get; set; }

		[XmlElement(ElementName = "stock")]
		public List<Stock> Stock { get; set; }
	}


}

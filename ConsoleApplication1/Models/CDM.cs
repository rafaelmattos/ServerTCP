using System.Xml.Serialization;

namespace ConsoleApplication1
{
    [XmlRoot(ElementName = "CDM")]
	public class CDM
	{
		public int Id { get; set; }

		[XmlElement(ElementName = "machineId")]
		public int MachineId { get; set; }

		[XmlElement(ElementName = "fw")]
		public Fw Fw { get; set; }

		[XmlElement(ElementName = "RecFw")]
		public string RecFw { get; set; }

		[XmlElement(ElementName = "RecTemplates")]
		public RecTemplates RecTemplates { get; set; }

		[XmlElement(ElementName = "model")]
		public Model Model { get; set; }

		[XmlElement(ElementName = "stocksConfig")]
		public StocksConfig StocksConfig { get; set; }

		[XmlElement(ElementName = "bagsConfig")]
		public BagsConfig BagsConfig { get; set; }
	}


}

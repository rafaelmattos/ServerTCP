using System.Xml.Serialization;

namespace ConsoleApplication1
{
    [XmlRoot(ElementName = "dev")]
	public class Dev
	{
		public int Id { get; set; }

		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }

		[XmlAttribute(AttributeName = "machineId")]
		public int MachineId { get; set; }

		[XmlAttribute(AttributeName = "mod")]
		public string Mod { get; set; }

		[XmlAttribute(AttributeName = "err")]
		public string Err { get; set; }

		[XmlAttribute(AttributeName = "clean")]
		public int Clean { get; set; }

		[XmlAttribute(AttributeName = "door")]
		public int Door { get; set; }

		[XmlAttribute(AttributeName = "devS")]
		public int DevS { get; set; }

		[XmlAttribute(AttributeName = "bag")]
		public int Bag { get; set; }

		[XmlAttribute(AttributeName = "cov")]
		public int Cov { get; set; }

		[XmlAttribute(AttributeName = "blk")]
		public int Blk { get; set; }

		[XmlAttribute(AttributeName = "ext")]
		public int Ext { get; set; }
	}


}

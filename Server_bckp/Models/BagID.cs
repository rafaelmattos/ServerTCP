using System.Xml.Serialization;

namespace Server
{
    [XmlRoot(ElementName = "bagID")]
	public class BagID
	{
        public int Id { get; set; }
        [XmlAttribute(AttributeName = "machineId")]
		public int MachineId { get; set; }

		[XmlText]
		public string Text { get; set; }

		[XmlAttribute(AttributeName = "N")]
		public int N { get; set; }
	}


}

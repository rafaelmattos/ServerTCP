using System.Collections.Generic;
using System.Xml.Serialization;

namespace Server
{
    [XmlRoot(ElementName = "ManualDeposits")]
	public class ManualDeposits
	{
		public int Id { get; set; }

		[XmlElement(ElementName = "manualDeposit")]
		public List<ManualDeposit> ManualDeposit { get; set; }
	}


}

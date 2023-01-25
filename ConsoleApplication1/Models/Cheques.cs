using System.Collections.Generic;
using System.Xml.Serialization;

namespace ConsoleApplication1
{
    [XmlRoot(ElementName = "cheques")]
	public class Cheques
	{
		public int Id { get; set; }

		[XmlElement(ElementName = "cheque")]
		public List<Cheque> Cheque { get; set; }
	}


}

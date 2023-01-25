using System;
using System.Xml.Serialization;

namespace ConsoleApplication1
{
    // using System.Xml.Serialization;
    // XmlSerializer serializer = new XmlSerializer(typeof(Root));
    // using (StringReader reader = new StringReader(xml))
    // {
    //    var test = (Root)serializer.Deserialize(reader);
    // }

    [XmlRoot(ElementName = "sw")]
	public class Sw
	{
        public int Id { get; set; }

        [XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }

		[XmlAttribute(AttributeName = "version")]
		public DateTime Version { get; set; }
	}


}

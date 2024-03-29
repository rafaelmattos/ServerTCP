﻿using System.Xml.Serialization;

namespace Server
{
    [XmlRoot(ElementName = "Amount")]
	public class Amount
	{
        public int Id { get; set; }

        [XmlAttribute(AttributeName = "amount")]
		public int amount { get; set; }

		[XmlAttribute(AttributeName = "curr")]
		public string Curr { get; set; }
	}


}

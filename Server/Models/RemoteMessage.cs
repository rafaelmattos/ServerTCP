using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Server
{
    [XmlRoot(ElementName = "RemoteMessage")]
	public class RemoteMessage
	{
		public int Id { get; set; }

		[XmlElement(ElementName = "bagID")]
		public List<BagID> BagID { get; set; }

		[XmlElement(ElementName = "TransactionID")]
		[Display(Name ="Transação")]
		public int? TransactionID { get; set; }

		[XmlElement(ElementName = "User")]
		[Display(Name = "Usuário")]
		public string User { get; set; }

		[XmlElement(ElementName = "UserName")]
		[Display(Name = "Nome do Usuário")]
		public string UserName { get; set; }

		[XmlElement(ElementName = "UserLevel")]
		[Display(Name = "Nível do Usuário")]
		public int UserLevel { get; set; }

		[XmlElement(ElementName = "UserAlternateID")]
		public string UserAlternateID { get; set; }

		[XmlElement(ElementName = "UserOrganization")]
		public string UserOrganization { get; set; }

		[XmlElement(ElementName = "UserInfo")]
		public string UserInfo { get; set; }

		[XmlElement(ElementName = "transactionRef")]
		public string TransactionRef { get; set; }

		[XmlElement(ElementName = "TransactionInfo")] 
		public string TransactionInfo { get; set; }

		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
		[XmlElement(ElementName = "accountingDate")]
		public DateTime? AccountingDate { get; set; }

		[XmlElement(ElementName = "Details")]
		public Details Details { get; set; }

		[XmlElement(ElementName = "isKit")]
		public int? IsKit { get; set; }

		[XmlElement(ElementName = "destDetails")]
		public DestDetails DestDetails { get; set; }

		[XmlElement(ElementName = "tickets")]
		public Tickets Tickets { get; set; }

		[XmlElement(ElementName = "cheques")]
		public Cheques Cheques { get; set; }

		[XmlElement(ElementName = "Conciliation")]
		public string Conciliation { get; set; }

		[XmlAttribute(AttributeName = "operation")]
		[Display(Name = "Operação")]
		public  string Operation { get; set; }

		public string Operacao { get; set; }
				
		[XmlAttribute(AttributeName = "DeviceID")]
		[Display(Name = "Equipamento")]
		public string DeviceID { get; set; }

		[XmlAttribute(AttributeName = "CustomerCode")]
		public string CustomerCode { get; set; }

		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
		[XmlAttribute(AttributeName = "Date")]
		[Display(Name = "Data")]
		public DateTime Date { get; set; }

		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm:ss}")]
		[XmlAttribute(AttributeName = "Time")]
		[Display(Name = "Hora")]
		public DateTime Time { get; set; }

		[XmlAttribute(AttributeName = "NOP")]
		public int NOP { get; set; }

		[XmlText]
		public string Text { get; set; }

		[XmlElement(ElementName = "envelopeID")]
		public int? EnvelopeID { get; set; }

		[XmlElement(ElementName = "sealID")]
		public int? SealID { get; set; }

		[XmlElement(ElementName = "ManualDeposits")]
		public ManualDeposits ManualDeposits { get; set; }

		[XmlElement(ElementName = "counting")]
		public Counting Counting { get; set; }

		[XmlElement(ElementName = "machineId")]
		public int? MachineId { get; set; }

		[XmlElement(ElementName = "ExecutedBy")]
		public int? ExecutedBy { get; set; }

		[XmlElement(ElementName = "ChannelID")]
		public int? ChannelID { get; set; }

		[XmlElement(ElementName = "ChannelName")]
		public string ChannelName { get; set; }

		[XmlElement(ElementName = "CashOut")]
		public CashOut CashOut { get; set; }

		[XmlElement(ElementName = "CashIn")]
		public CashIn CashIn { get; set; }

		[XmlElement(ElementName = "UserID")]
		public int? UserID { get; set; }
	}


}

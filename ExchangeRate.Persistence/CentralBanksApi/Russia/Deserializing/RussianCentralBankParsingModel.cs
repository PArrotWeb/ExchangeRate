using System.Xml.Serialization;
#pragma warning disable CS8618

namespace ExchangeRate.Persistence.CentralBanksApi.Russia.Deserializing;

[XmlRoot(ElementName = "ValCurs")]
public class ValCurs
{

	[XmlElement(ElementName = "Valute")]
	public List<Valute> Valute { get; set; }

	[XmlIgnore]
	[XmlAttribute(AttributeName = "Date")]
	public DateTime Date { get; set; }

	[XmlIgnore]
	[XmlAttribute(AttributeName = "name")]
	public string Name { get; set; }
}

[XmlRoot(ElementName = "Valute")]
public class Valute
{

	[XmlElement(ElementName = "NumCode")]
	public int NumCode { get; set; }

	[XmlElement(ElementName = "CharCode")]
	public string CharCode { get; set; }

	[XmlElement(ElementName = "Nominal")]
	public int Nominal { get; set; }

	[XmlElement(ElementName = "Name")]
	public string Name { get; set; }

	[XmlElement(ElementName = "Value")]
	public string Value { get; set; }

	[XmlIgnore]
	[XmlAttribute(AttributeName = "ID")]
	public string Id { get; set; }
}


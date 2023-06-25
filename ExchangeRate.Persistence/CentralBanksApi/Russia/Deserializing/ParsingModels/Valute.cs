using System.Xml.Serialization;

namespace ExchangeRate.Persistence.CentralBanksApi.Russia.Deserializing.ParsingModels;

[Serializable]
public sealed record Valute
{

	[XmlAttribute("ID")]
	public string Id { get; init; } = null!;

	[XmlElement("NumCode")]
	public string NumCode { get; init; } = null!;

	[XmlElement("CharCode")]
	public string CharCode { get; init; } = null!;

	[XmlElement("Nominal")]
	public string Nominal { get; init; } = null!;

	[XmlElement("Name")]
	public string Name { get; init; } = null!;

	[XmlElement("Value")]
	public string Value { get; init; } = null!;
}
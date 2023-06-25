using System.Xml.Serialization;

namespace ExchangeRate.Persistence.CentralBanksApi.Russia.Deserializing.ParsingModels;

[Serializable]
[XmlRoot("ValCurs")]
public sealed record ValCurs
{

	[XmlAttribute("Date")]
	public string Date { get; init; } = null!;

	[XmlAttribute("name")]
	public string Name { get; init; } = null!;

	[XmlElement("Valute")]
	public List<Valute> Items { get; init; } = null!;
}
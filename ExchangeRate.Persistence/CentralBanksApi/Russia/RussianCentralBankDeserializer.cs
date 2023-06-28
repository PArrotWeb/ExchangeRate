using System.Globalization;
using System.Xml.Linq;
using ExchangeRate.Domain.Entities;
using ExchangeRate.Persistence.CentralBanksApi.Deserializers;

namespace ExchangeRate.Persistence.CentralBanksApi.Russia;

public sealed class RussianCentralBankDeserializer : CentralBankDeserializer
{
	private readonly NumberFormatInfo _format = new() {NumberDecimalSeparator = ","};

	public override async Task<List<Currency>> DeserializeAsync(string data, CancellationToken cancellationToken)
	{
		var valCurs = XElement.Parse(data);
		var currencies = new List<Currency>();

		await Task.Run(() =>
		{
			foreach (var item in valCurs.Elements("Valute"))
			{
				var currency = new Currency
				{
					Name = item.Element("Name")?.Value ?? ThrowException("Name"),
					CharCode = item.Element("CharCode")?.Value ?? ThrowException("CharCode"),
					NumCode = Convert.ToInt16(item.Element("NumCode")?.Value ?? ThrowException("NumCode")),
					Nominal = Convert.ToDecimal(item.Element("Nominal")?.Value ?? ThrowException("Nominal"), _format),
					Value = Convert.ToDecimal(item.Element("Value")?.Value ?? ThrowException("Value"), _format)
				};

				currencies.Add(currency);
			}
		}, cancellationToken);
		
		return currencies;
	}
}
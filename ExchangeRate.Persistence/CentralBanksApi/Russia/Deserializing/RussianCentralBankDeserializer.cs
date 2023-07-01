using System.Globalization;
using ExchangeRate.Domain.Entities;
using ExchangeRate.Persistence.CentralBanksApi.Deserializers;

namespace ExchangeRate.Persistence.CentralBanksApi.Russia.Deserializing;

public sealed class RussianCentralBankDeserializer : XmlCentralBankDeserializer<ValCurs>
{
	private readonly NumberFormatInfo _format = new() {NumberDecimalSeparator = ","};

	protected override async Task<List<Currency>> MapToCurrenciesAsync(ValCurs parsedData,
		CancellationToken cancellationToken)
	{
		var currencies = new List<Currency>();

		await Task.Run(() =>
		{
			foreach (var item in parsedData.Valute)
			{
				var currency = new Currency
				{
					Name = item.Name,
					CharCode = item.CharCode,
					NumCode = Convert.ToInt16(item.NumCode),
					Nominal = Convert.ToInt16(item.Nominal),
					Value = Convert.ToDecimal(item.Value, _format)
				};

				currencies.Add(currency);
			}
		}, cancellationToken);

		return currencies;
	}
}
using System.Globalization;
using ExchangeRate.Domain.Entities;
using ExchangeRate.Persistence.CentralBanksApi.Deserializers;

namespace ExchangeRate.Persistence.CentralBanksApi.Thailand.Deserializing;

public sealed class ThailandCentralBankDeserializer : JsonCentralBankDeserializer<Root>
{
	private readonly NumberFormatInfo _format = new() {NumberDecimalSeparator = "."};

	protected override async Task<List<Currency>> MapToCurrenciesAsync(Root parsedData,
		CancellationToken cancellationToken)
	{
		var currencies = new List<Currency>();

		await Task.Run(() =>
		{
			foreach (var item in parsedData.Result.Data.DataDetail)
			{
				var currency = new Currency
				{
					Name = item.CurrencyNameEng,
					CharCode = item.CurrencyId,
					NumCode = null!,
					Nominal = 1,
					Value = Convert.ToDecimal(item.MidRate, _format)
				};

				currencies.Add(currency);
			}
		}, cancellationToken);

		return currencies;
	}
}
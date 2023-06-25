using System.Globalization;
using ExchangeRate.Domain.Entities;
using ExchangeRate.Persistence.CentralBanksApi.Deserializers;
using ExchangeRate.Persistence.CentralBanksApi.Russia.Deserializing.ParsingModels;

namespace ExchangeRate.Persistence.CentralBanksApi.Russia.Deserializing;

public sealed class RussianCentralBankDeserializer : XmlCentralBankDeserializer<ValCurs>
{
	protected override async Task<List<Currency>> MapToDomainModel(ValCurs parsedData,
		CancellationToken cancellationToken)
	{
		var formatProvider = new NumberFormatInfo {NumberDecimalSeparator = ","};

		var currencies = new List<Currency>();

		await Task.Run(() =>
		{
			foreach (var item in parsedData.Items)
			{
				var currency = new Currency
				{
					NumCode = Convert.ToInt16(item.NumCode),
					CharCode = item.CharCode,
					Nominal = Convert.ToDecimal(item.Nominal, formatProvider),
					Name = item.Name,
					Value = Convert.ToDecimal(item.Value, formatProvider)
				};

				currencies.Add(currency);
			}
		}, cancellationToken);

		return currencies;
	}
}
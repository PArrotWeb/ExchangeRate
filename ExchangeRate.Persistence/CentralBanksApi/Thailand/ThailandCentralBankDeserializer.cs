using System.Globalization;
using ExchangeRate.Domain.Entities;
using ExchangeRate.Persistence.CentralBanksApi.Deserializers;
using Newtonsoft.Json.Linq;

namespace ExchangeRate.Persistence.CentralBanksApi.Thailand;

public sealed class ThailandCentralBankDeserializer : CentralBankDeserializer
{
	private readonly NumberFormatInfo _format = new() {NumberDecimalSeparator = "."};

	public override async Task<List<Currency>> DeserializeAsync(string data, CancellationToken cancellationToken)
	{
		var currencies = new List<Currency>();

		var json = JObject.Parse(data);
		JArray dataDetail = json["result"]?["data"]?["data_detail"] ?? ThrowException("data_detail");

		await Task.Run(() =>
		{
			foreach (var item in dataDetail)
			{
				Console.WriteLine(item.ToString());
				
				var currency = new Currency
				{
					Name = item["currency_name_eng"]?.Value<string>() ?? ThrowException("currency_name_eng"),
					CharCode = item["currency_id"]?.Value<string>() ?? ThrowException("currency_id"),
					NumCode = null!,
					Nominal = 1,
					Value = Convert.ToDecimal(item["mid_rate"]?.Value<string>() ?? ThrowException("mid_rate"), _format)
				};

				currencies.Add(currency);
			}
		}, cancellationToken);

		return currencies;
	}
}
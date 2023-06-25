using ExchangeRate.Domain.Entities;
using ExchangeRate.Persistence.CentralBanksApi.Russia.Deserializing;

namespace ExchangeRate.Persistence.CentralBanksApi.Russia;

public sealed class RussianCentralBankApi : CentralBankApi
{
	private readonly Currency _countryCurrency = new()
	{
		Name = "Российский рубль",
		NumCode = 643,
		CharCode = "RUB",
		Nominal = 1,
		Value = 1
	};
	private readonly string _countryName = Countries.Russia;
	private readonly RussianCentralBankDeserializer _deserializer = new();
	private readonly string _url = "https://www.cbr.ru/scripts/XML_daily.asp";

	protected override string GetCentralBankApiUrl()
	{
		return _url;
	}

	protected override Currency GetCountryCurrency()
	{
		return _countryCurrency;
	}

	protected override RussianCentralBankDeserializer GetCentralBankDeserializer()
	{
		return _deserializer;
	}

	protected override string GetCountryName()
	{
		return _countryName;
	}
}
using ExchangeRate.Domain.Entities;
using ExchangeRate.Persistence.CentralBanksApi.Deserializers;
using ExchangeRate.Persistence.CentralBanksApi.Thailand.Deserializing;

namespace ExchangeRate.Persistence.CentralBanksApi.Thailand;

public sealed class ThailandCentralBankApi : CentralBankApi
{
	private const string CountryName = Countries.Thailand;
	private const string Url = "https://apigw1.bot.or.th/bot/public/Stat-ExchangeRate/v2/DAILY_AVG_EXG_RATE/";

	// Release schedule : Every business day at 6.00 p.m. (BKK-GMT+07:00)
	private const int RefreshMinutesTime = 1090; // 6.00 p.m. in minutes + inaccuracy 10 minutes
	private const int GmtMinutesOffset = 420;    // GMT+07:00 in minutes

	private const string XIbmClientId = "f8d55e8b-4306-4e39-be0c-17b29fe462c5";

	private readonly Currency _countryCurrency = new()
	{
		Name = "THB : THAI BAHT (THB) ",
		NumCode = null!,
		CharCode = "THB",
		Nominal = 1,
		Value = 1
	};

	private readonly ThailandCentralBankDeserializer _deserializer = new();
	private readonly TimeSpan _gmtOffset = TimeSpan.FromMinutes(GmtMinutesOffset);
	private readonly TimeSpan _refreshTimeOffset = TimeSpan.FromMinutes(RefreshMinutesTime);

	protected override string GetCentralBankApiUrl()
	{
		var currentTime = DateTime.UtcNow;
		var offsetCurrentTime = currentTime + _gmtOffset;

		var availableDateTime = offsetCurrentTime - _refreshTimeOffset;
		while (availableDateTime.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
		{
			var decreaseDayTimeSpan = TimeSpan.FromDays(1);
			availableDateTime -= decreaseDayTimeSpan;
		}

		var date = availableDateTime.ToString("yyyy-MM-dd");
		var url = $"{Url}?start_period={date}&end_period={date}";

		return url;
	}

	protected override HttpClient CreateHttpClient()
	{
		var httpClient = new HttpClient();
		httpClient.DefaultRequestHeaders.Clear();
		httpClient.DefaultRequestHeaders.Add("X-IBM-Client-Id", XIbmClientId);

		return httpClient;
	}

	protected override Currency GetCountryCurrency()
	{
		return _countryCurrency;
	}

	protected override CentralBankDeserializer GetCentralBankDeserializer()
	{
		return _deserializer;
	}

	protected override string GetCountryName()
	{
		return CountryName;
	}
}
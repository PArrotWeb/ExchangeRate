using System.Text;
using ExchangeRate.Domain.Entities;
using ExchangeRate.Persistence.CentralBanksApi.Deserializers;

namespace ExchangeRate.Persistence.CentralBanksApi;

public abstract class CentralBankApi
{

	private static readonly TimeSpan CacheTime = TimeSpan.FromHours(1);


	private readonly object _lockCentralBankCache = new();

	private CentralBank? _centralBankCache;

	private CentralBank? CentralBankCache
	{
		get
		{
			lock (_lockCentralBankCache)
			{
				return _centralBankCache;
			}
		}
		set
		{
			lock (_lockCentralBankCache)
			{
				_centralBankCache = value;
			}
		}
	}

	protected abstract string GetCentralBankApiUrl();

	protected abstract Currency GetCountryCurrency();

	protected abstract ICentralBankDeserializer GetCentralBankDeserializer();

	protected abstract string GetCountryName();

	private bool IsCacheExpired()
	{
		return CentralBankCache?.LastUpdated == null || DateTime.Now - CentralBankCache?.LastUpdated > CacheTime;
	}

	private void UpdateCache(CentralBank centralBank)
	{
		CentralBankCache = centralBank;
		CentralBankCache.LastUpdated = DateTime.Now;
	}

	/// <summary>Get central bank data from cache or API</summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public async Task<CentralBank> GetCentralBankAsync(CancellationToken cancellationToken)
	{
		// get data from cache if it's not expired
		if (CentralBankCache != null && IsCacheExpired() == false)
		{
			Console.WriteLine($"Get data from cache. ({GetCountryName()})");
			return CentralBankCache;
		}

		// get data from API if cache is expired or empty
		Console.WriteLine($"Get data from cache... ({GetCountryName()})");

		// get response from API
		var responseContent = await GetDataFromUrlAsync(GetCentralBankApiUrl(), cancellationToken);

		// deserialize to domain model
		var currencies = await GetCentralBankDeserializer().DeserializeAsync(responseContent, cancellationToken);

		// add country currency to currencies for convenience
		currencies.Add(GetCountryCurrency());

		// create domain model
		var centralBank = new CentralBank
		{
			Country = GetCountryName(),
			Currencies = currencies
		};

		// update cache
		UpdateCache(centralBank);

		// return domain model
		return centralBank;
	}

	/// <summary>Get data from api by url</summary>
	/// <param name="url">Central bank api url</param>
	/// <param name="cancellationToken"></param>
	/// <returns>String of response</returns>
	private static async Task<string> GetDataFromUrlAsync(string url, CancellationToken cancellationToken)
	{
		var httpClient = new HttpClient();
		httpClient.DefaultRequestHeaders.Clear();

		var response = await httpClient.GetAsync(url, cancellationToken);

		Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
		var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);

		return responseContent;
	}
}
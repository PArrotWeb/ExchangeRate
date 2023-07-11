using System.Text;
using ExchangeRate.Domain.Entities;
using ExchangeRate.Persistence.CentralBanksApi.Deserializers;

namespace ExchangeRate.Persistence.CentralBanksApi;

public abstract class CentralBankApi
{

	// period of cache time
	private static readonly TimeSpan CacheTime = TimeSpan.FromHours(3);

	// lock object for thread safety
	private readonly object _lockCentralBankCache = new();

	// cache for central bank data with thread safety logic
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

	/// <summary>
	/// Get central bank api url
	/// </summary>
	/// <returns>Final URL</returns>
	protected abstract string GetCentralBankApiUrl();

	/// <summary>
	/// Currency for country where central bank is located
	/// </summary>
	/// <returns>Currency</returns>
	protected abstract Currency GetCountryCurrency();

	protected abstract CentralBankDeserializer GetCentralBankDeserializer();

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
			return CentralBankCache;
		}

		// get response from API
		var responseContent = await GetDataFromUrlAsync(GetCentralBankApiUrl(), cancellationToken);

		// deserialize to domain model
		List<Currency> currencies;
		try
		{
			currencies = await GetCentralBankDeserializer().DeserializeAsync(responseContent, cancellationToken);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);

			// return cache if api not available
			if (CentralBankCache == null)
			{
				throw new Exception("Central bank API is not available");
			}

			return CentralBankCache;
		}

		// add country currency to currencies for convenience
		if (currencies.All(x => x.CharCode != GetCountryCurrency().CharCode))
		{
		    currencies.Add(GetCountryCurrency());
		}
		
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
	private async Task<string> GetDataFromUrlAsync(string url, CancellationToken
		cancellationToken)
	{
		var httpClient = CreateHttpClient();
		var response = await httpClient.GetAsync(url, cancellationToken);

		Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
		var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);

		return responseContent;
	}

	/// <summary>
	/// Create HttpClient and set headers or other
	/// </summary>
	/// <returns>new HttpClient</returns>
	protected virtual HttpClient CreateHttpClient()
	{
		var httpClient = new HttpClient();
		httpClient.DefaultRequestHeaders.Clear();
		return httpClient;
	}
}
using ExchangeRate.Application.Interfaces;
using ExchangeRate.Domain.Entities;
using ExchangeRate.Persistence.CentralBanksApi;
using ExchangeRate.Persistence.CentralBanksApi.Russia;
using ExchangeRate.Persistence.CentralBanksApi.Thailand;
using ExchangeRate.Persistence.Common.Exceptions;

namespace ExchangeRate.Persistence;

public sealed class CentralBankRepository : ICentralBankRepository
{
	// Dictionary of central bank api for each country. 
	// Add all available api here
	private readonly Dictionary<string, CentralBankApi> _centralBankApis = new()
	{
		{
			Countries.Russia,
			new RussianCentralBankApi()
		},
		{
			Countries.Thailand,
			new ThailandCentralBankApi()
		}
	};

	#region ICentralBankRepository Members
	/// <summary>Get all available central banks from all apis</summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public async Task<List<CentralBank>> GetCentralBanksAsync(CancellationToken cancellationToken)
	{
		var centralBanks = new List<CentralBank>();
		foreach (var item in _centralBankApis)
		{
			centralBanks.Add(await item.Value.GetCentralBankAsync(cancellationToken));
		}

		return centralBanks;
	}

	/// <summary>Get central bank data from api by country</summary>
	/// <param name="country">String from Countries</param>
	/// <param name="cancellationToken"></param>
	/// <returns>Domain model CentralBank</returns>
	/// <exception cref="Exception">Country not found</exception>
	public async Task<CentralBank> GetCentralBankAsync(string country, CancellationToken cancellationToken)
	{
		// check if country is not supported
		if (_centralBankApis.ContainsKey(country) == false)
		{
			throw new NotFoundException($"Central bank API for {country} is not found");
		}

		return await _centralBankApis[country].GetCentralBankAsync(cancellationToken);
	}
	#endregion

}
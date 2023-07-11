using ExchangeRate.Domain.Entities;

namespace ExchangeRate.Application.Interfaces;

public interface ICentralBankRepository
{
	/// <summary>
	/// Get all available central banks
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<List<CentralBank>> GetCentralBanksAsync(CancellationToken cancellationToken);

	/// <summary>
	/// Get central bank by one of the available countries
	/// </summary>
	/// <param name="country"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	Task<CentralBank> GetCentralBankAsync(string country, CancellationToken cancellationToken);
}
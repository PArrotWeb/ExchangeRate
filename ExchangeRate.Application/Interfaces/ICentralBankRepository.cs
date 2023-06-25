using ExchangeRate.Domain.Entities;

namespace ExchangeRate.Application.Interfaces;

public interface ICentralBankRepository
{
	Task<List<CentralBank>> GetCentralBanksAsync(CancellationToken cancellationToken);

	Task<CentralBank> GetCentralBankAsync(string country, CancellationToken cancellationToken);
}
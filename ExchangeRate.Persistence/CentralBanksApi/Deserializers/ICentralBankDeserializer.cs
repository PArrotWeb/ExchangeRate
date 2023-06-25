using ExchangeRate.Domain.Entities;

namespace ExchangeRate.Persistence.CentralBanksApi.Deserializers;

public interface ICentralBankDeserializer
{
	Task<List<Currency>> DeserializeAsync(string data, CancellationToken cancellationToken);
}
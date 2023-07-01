using ExchangeRate.Domain.Entities;

namespace ExchangeRate.Persistence.CentralBanksApi.Deserializers;

public abstract class CentralBankDeserializer
{
	public abstract Task<List<Currency>> DeserializeAsync(string data, CancellationToken cancellationToken);

	protected static dynamic ThrowException(string valueName)
	{
		throw new InvalidOperationException($"{valueName} is null");
	}
}
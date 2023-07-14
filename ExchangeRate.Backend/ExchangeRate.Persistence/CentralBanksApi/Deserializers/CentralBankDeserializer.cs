using ExchangeRate.Domain.Entities;

namespace ExchangeRate.Persistence.CentralBanksApi.Deserializers;

/// <summary>
/// Base class for deserializing central bank api data
/// </summary>
public abstract class CentralBankDeserializer
{
	/// <summary>
	/// Deserialize string data to list of currencies
	/// </summary>
	/// <param name="data">Response data from api in string (xml, json, ..)</param>
	/// <param name="cancellationToken"></param>
	/// <returns>Deserialized list of currencies</returns>
	public abstract Task<List<Currency>> DeserializeAsync(string data, CancellationToken cancellationToken);
}
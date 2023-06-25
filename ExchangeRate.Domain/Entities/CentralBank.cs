namespace ExchangeRate.Domain.Entities;

public class CentralBank
{
	public string Country { get; init; } = null!;

	public DateTime? LastUpdated { get; set; }

	public List<Currency> Currencies { get; init; } = null!;
}
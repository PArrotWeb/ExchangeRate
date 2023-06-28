namespace ExchangeRate.Domain.Entities;

public class Currency
{
	public string Name { get; set; } = null!;

	public string CharCode { get; set; } = null!;

	public short? NumCode { get; set; }

	public decimal Nominal { get; set; } = 1;

	public decimal Value { get; set; }
}
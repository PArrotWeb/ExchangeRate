using MediatR;

namespace ExchangeRate.Application.Requests.Queries.ConvertRussiaCentralBank;

public sealed record ConvertCentralBankQuery : IRequest<ConvertDto>
{
	public string Country { get; init; } = null!;

	public decimal Amount { get; init; }

	public string FromCharCode { get; init; } = null!;

	public string ToCharCode { get; init; } = null!;
}
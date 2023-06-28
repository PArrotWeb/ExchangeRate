using MediatR;

namespace ExchangeRate.Application.Requests.CentralBanks.Queries.Convert;

public sealed record GetConvertedCurrencyQuery : IRequest<ConvertDto>
{
	public string Country { get; init; } = null!;

	public decimal Amount { get; init; }

	public string FromCharCode { get; init; } = null!;

	public string ToCharCode { get; init; } = null!;
}
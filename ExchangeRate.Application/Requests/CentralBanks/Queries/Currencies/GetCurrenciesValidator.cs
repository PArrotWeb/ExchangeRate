using FluentValidation;

namespace ExchangeRate.Application.Requests.CentralBanks.Queries.Currencies;

public class GetCurrenciesValidator : AbstractValidator<GetCurrenciesQuery>
{
	public GetCurrenciesValidator()
	{
		// check if country is empty
		RuleFor(q => q.Country)
			.NotEmpty()
			.WithMessage("Country is required.");
		
		// check if country length from 2 to 45
		RuleFor(q => q.Country)
			.Length(2, 45)
			.WithMessage("Country must be between 2 and 45 characters.");
		
		// check if country includes only eng upper case letters
		RuleFor(q => q.Country)
			.Matches("^[A-Z]+$")
			.WithMessage("Country must include only eng upper case letters.");
	}
}
using FluentValidation;

namespace ExchangeRate.Application.Requests.CentralBanks.Queries.Convert;

public class GetConvertedCurrencyValidator : AbstractValidator<GetConvertedCurrencyQuery>
{
	public GetConvertedCurrencyValidator()
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

		// check if fromCharCode is empty
		RuleFor(q => q.FromCharCode)
			.NotEmpty()
			.WithMessage("FromCharCode is required.");

		// check if toCharCode length is 3
		RuleFor(q => q.FromCharCode)
			.Length(3)
			.WithMessage("FromCharCode must be 3 characters.");

		// check if fromCharCode includes only eng upper case letters
		RuleFor(q => q.FromCharCode)
			.Matches("^[A-Z]+$")
			.WithMessage("FromCharCode must include only eng upper case letters.");

		// check if toCharCode is empty
		RuleFor(q => q.ToCharCode)
			.NotEmpty()
			.WithMessage("ToCharCode is required.");

		// check if toCharCode length is 3. ISO 4217
		RuleFor(q => q.ToCharCode)
			.Length(3)
			.WithMessage("ToCharCode must be 3 characters.");

		// check if toCharCode includes only eng upper case letters
		RuleFor(q => q.ToCharCode)
			.Matches("^[A-Z]+$")
			.WithMessage("ToCharCode must include only eng upper case letters.");

		// check if amount is greater than 0
		RuleFor(q => q.Amount)
			.GreaterThan(0)
			.WithMessage("Amount must be greater than 0.");

		// check if amount is less than 79228162514264337593543950335
		RuleFor(q => q.Amount)
			.LessThan(decimal.MaxValue)
			.WithMessage("Amount must be less than 79228162514264337593543950335.");

		// check if amount has 4 decimal places
		RuleFor(q => q.Amount)
			.PrecisionScale(28, 4, true)
			.WithMessage("Amount must have 4 decimal places.");
	}
}
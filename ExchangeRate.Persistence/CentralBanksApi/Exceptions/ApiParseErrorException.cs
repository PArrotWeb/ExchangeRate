namespace ExchangeRate.Persistence.CentralBanksApi.Exceptions;

public class ApiParseErrorException : Exception
{
	public ApiParseErrorException(string element) : base($"Failed to parse data from central bank API ({element})")
	{

	}
}
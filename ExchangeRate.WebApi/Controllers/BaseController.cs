using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRate.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public abstract class BaseController : ControllerBase
{
	protected readonly ISender mediator;

	protected BaseController(ISender mediator)
	{
		this.mediator = mediator;
	}
}
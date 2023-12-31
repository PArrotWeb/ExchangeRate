﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRate.WebApi.Controllers;

/// <summary>
/// Base controller for all controllers in this project
/// </summary>
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
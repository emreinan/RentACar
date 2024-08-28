using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Brands.Queries.GetList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BrandsController : BaseController
	{
		[HttpPost]
		public async Task<IActionResult> Add([FromBody] CreateBrandCommand command)
		{
			var response = await Mediator.Send(command);
			return Ok(response);
		}

		[HttpGet]
		public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
		{
			var query = new GetListBrandQuery { PageRequest = pageRequest };
			var response = await Mediator.Send(query);
			return Ok(response);
		}

		[HttpGet("id")]
		public async Task<IActionResult> GetById([FromRoute]Guid id)
		{
			var query = new GetByIdBrandQuery { Id = id };
			var response = await Mediator.Send(query);
			return Ok(response);
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromBody] UpdateBrandCommand command)
		{
			var response = await Mediator.Send(command);
			return Ok(response);
		}
	}
}

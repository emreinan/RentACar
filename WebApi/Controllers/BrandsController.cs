using Application.Features.Brands.Commands.Create;
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
	}
}

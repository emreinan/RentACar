using Application.Features.Brands.Commands.Create;
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
	}
}

using Microsoft.AspNetCore.Mvc;

namespace Faluf.WASM.Server.Controllers;

[Route("auth")]
[ApiController]
public sealed class AuthController : ControllerBase
{
	[HttpGet("Test")]
	public ActionResult GetTest()
	{
		return Ok("Hello World");
	}
}
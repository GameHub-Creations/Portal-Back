using Microsoft.AspNetCore.Mvc;
using SSO.Controllers.RequestModels;
using SSO.Controllers.Results;
using SSO.Handlers;

namespace SSO.Controllers;

[Route("api/v1")]
public class AccountController : Controller
{
    private readonly IUserHandler _userHandler;

    public AccountController(IUserHandler userHandler)
    {
        _userHandler = userHandler;
    }

    [HttpPost("registry")]
    public async Task<IActionResult> Registry([FromBody] RegistryModel model)
    {
        if (!ModelState.IsValid) return BadRequest(new Error("ModelException", "Invalid model in request"));

        await _userHandler.Registry(model);

        return Ok();
    }

    [HttpPost("authorize")]
    public async Task<IActionResult> Authorize([FromBody] LoginModel model)
    {
        if (!ModelState.IsValid) return BadRequest(new Error("ModelException", "Invalid model in request"));

        var result = await _userHandler.Authorize(model);
        
        return Ok(result.Response());
    }
}
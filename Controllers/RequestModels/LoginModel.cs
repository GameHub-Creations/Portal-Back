using System.ComponentModel.DataAnnotations;

namespace SSO.Controllers.RequestModels;

public class LoginModel
{
    [Required] public string Email { get; set; }
    [Required] public string Password { get; set; }
}
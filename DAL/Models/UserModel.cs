using System.ComponentModel.DataAnnotations;

namespace SSO.DAL.Models;

public class UserModel
{
    [Key]
    public string UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public TokenModel TokenModel { get; set; }
}
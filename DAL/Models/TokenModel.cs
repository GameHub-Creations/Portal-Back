using System.ComponentModel.DataAnnotations;

namespace SSO.DAL.Models;

public class TokenModel
{
    [Key]
    public string UserId { get; set; }
    public string Token { get; set; }
    public UserModel UserModel { get; set; }
}
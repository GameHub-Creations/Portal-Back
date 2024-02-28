using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SSO.DAL.Models;
using SSO.Controllers.RequestModels;
using SSO.Controllers.ResponseModels;
using SSO.Controllers.Results;
using SSO.DAL;
using SSO.Exceptions;

namespace SSO.BL;

public class UserBl : IUserBl
{
    private readonly IUserDal _userDal;
    private const string SecretKey = "$2a$10$PBG.tZ/Y9sTKMch3g4UIKubODpo7JYUsGYu0VvCDql5XfH5q1EIMS";
    private readonly SymmetricSecurityKey _signingKey = new(Encoding.ASCII.GetBytes(SecretKey));

    public UserBl(IUserDal userDal)
    {
        _userDal = userDal;
    }

    public async Task<Result> CreateUser(RegistryModel model)
    {
        var userRecord = await _userDal.GetUserRecordByEmail(model.Email);

        if (userRecord != null)
        {
            throw new UserAllReadyExistException();
        }

        var user = new UserModel
        {
            UserId = Guid.NewGuid().ToString(),
            Email = model.Email,
            Name = model.Name,
            Password = model.Password
        };

        await _userDal.AddUser(user);

        return Result.Success();
    }

    public async Task<Result> GetAccessToken(LoginModel model)
    {
        var userRecord = await _userDal.GetUserRecordByEmail(model.Email);
        if (userRecord == null)
        {
            throw new InvalidCredentialsException();
        }

        if (model.Password != userRecord.Password)
        {
            throw new InvalidCredentialsException();
        }

        var token = GenerateToken(userRecord.Name);

        var tokenRecord = await _userDal.GetTokenRecordByUserId(userRecord.UserId);

        if (tokenRecord == null)
        {
            await _userDal.AddToken(
                new TokenModel
                {
                    UserId = userRecord.UserId, 
                    Token = token
                });
        }
        else
        {
            tokenRecord.Token = token;
            await _userDal.UpdateToken(tokenRecord);
        }

        return Result.Success(new LoginResponse(token));
    }

    private string GenerateToken(string username)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username)
        };

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
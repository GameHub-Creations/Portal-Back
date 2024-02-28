using SSO.BL;
using SSO.Controllers.RequestModels;
using SSO.Controllers.Results;

namespace SSO.Handlers;

public class UserHandler: IUserHandler
{
    private readonly IUserBl _userBl;

    public UserHandler(IUserBl userBl)
    {
        _userBl = userBl;
    }

    public async Task<Result> Registry(RegistryModel model)
    {
        var result = await _userBl.CreateUser(model);

        return result;
    }

    public async Task<Result> Authorize(LoginModel model)
    {
        var result = await _userBl.GetAccessToken(model);

        return result;
    }

}
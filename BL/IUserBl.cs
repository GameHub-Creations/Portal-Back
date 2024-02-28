using SSO.Controllers.RequestModels;
using SSO.Controllers.Results;

namespace SSO.BL;

public interface IUserBl
{
    public Task<Result> CreateUser(RegistryModel model);
    public Task<Result> GetAccessToken(LoginModel model);
}
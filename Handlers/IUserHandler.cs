using SSO.Controllers.RequestModels;
using SSO.Controllers.Results;

namespace SSO.Handlers;

public interface IUserHandler
{
    public Task<Result> Registry(RegistryModel model);
    public Task<Result> Authorize(LoginModel model);
}
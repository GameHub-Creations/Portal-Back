using SSO.DAL.Models;

namespace SSO.DAL;

public interface IUserDal
{
    public Task<UserModel?> GetUserRecordByEmail(string email);
    public Task<TokenModel?> GetTokenRecordByUserId(string userId);
    public Task AddUser(UserModel userModel);
    public Task AddToken(TokenModel tokenModel);
    public Task UpdateToken(TokenModel tokenModel);
}
using Microsoft.EntityFrameworkCore;
using SSO.DAL.Models;

namespace SSO.DAL;

public class UserDal : IUserDal
{
    private readonly ApplicationContext _dbContext;

    public UserDal(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserModel?> GetUserRecordByEmail(string email)
    {
        var userRecord = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email.ToLower());
        return userRecord;
    }

    public async Task<TokenModel?> GetTokenRecordByUserId(string userId)
    {
        var tokenRecord = await _dbContext.Tokens.FirstOrDefaultAsync(t => t.UserId == userId);
        return tokenRecord;
    }


    public async Task AddUser(UserModel userModel)
    {
        await _dbContext.Users.AddAsync(userModel);
        await SaveChangesAsync();
    }

    public async Task AddToken(TokenModel tokenModel)
    {
        await _dbContext.Tokens.AddAsync(tokenModel);
        await SaveChangesAsync();
    }

    public async Task UpdateToken(TokenModel tokenModel)
    {
        _dbContext.Tokens.Update(tokenModel);
        await SaveChangesAsync();
    }

    private async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
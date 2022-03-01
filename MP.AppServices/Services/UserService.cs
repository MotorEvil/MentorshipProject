namespace MP.AppServices.Services;

public class UserService : IUserService
{
    private readonly IMongoCollection<UserModel> _users;

    public UserService(IAppDbConnection db)
    {
        _users = db.UserCollection;
    }

    public Task CreateUser(UserModel user)
    {
        return _users.InsertOneAsync(user);
    }

    public async Task<List<UserModel>> GetUsersAasync()
    {
        var result = await _users.FindAsync(_ => true);
        return result.ToList();
    }

    public async Task<UserModel> GetUserById(string id)
    {
        var user = await _users.FindAsync(x => x.Id == id);
        return user.FirstOrDefault();
    }

    public Task UpdateUser(UserModel user)
    {
        var filter = Builders<UserModel>.Filter.Eq("Id", user.Id);
        return _users.ReplaceOneAsync(filter, user, new ReplaceOptions { IsUpsert = true });
    }

    public Task DeleteUser(string id)
    {
        return _users.DeleteOneAsync(x => x.Id == id);
    }
}

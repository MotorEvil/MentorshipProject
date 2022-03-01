
namespace MP.AppServices.Services
{
    public interface IUserService
    {
        Task CreateUser(UserModel user);
        Task DeleteUser(string id);
        Task<UserModel> GetUserById(string id);
        Task<List<UserModel>> GetUsersAasync();
        Task UpdateUser(UserModel user);
    }
}


using API.Blog.BackEnd.Domain.Entities;

namespace API.Blog.BackEnd.Domain.Interfaces
{
    public interface IUserService
    {
        Task CreateUserAsync(User user);
        Task<List<User>> DisplayAllUsersAsync();
        Task<User> DisplayUserByIdAsync(string id);
        Task UpdateUserByIdAsync(User user, string Id);
        Task DeleteUserByIdAsync(string id);
    }
}

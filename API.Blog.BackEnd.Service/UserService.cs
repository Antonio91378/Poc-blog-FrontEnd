

using API.Blog.BackEnd.Domain.Entities;
using API.Blog.BackEnd.Domain.Interfaces;
using API.Blog.BackEnd.Infra.Repositories;

namespace API.Blog.BackEnd.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService()
        {
            _userRepo = new UserRepo();
        }

        public async Task CreateUserAsync(User user)
        {
            await _userRepo.CreateUserAsync(user);
        }

        public async Task DeleteUserByIdAsync(string id)
        {
            await _userRepo.DeleteUserByIdAsync(id);
        }

        public async Task<List<User>> DisplayAllUsersAsync()
        {
            var users = await _userRepo.DisplayAllUsersAsync();
            return users;
        }

        public async Task<User> DisplayUserByIdAsync(string id)
        {
            var user = await _userRepo.DisplayUserByIdAsync(id);
            return user;
        }

        public async Task UpdateUserByIdAsync(User user, string Id)
        {
            var _user = await _userRepo.DisplayUserByIdAsync(Id);
            if (_user is not null)
            {
                var attUser = _userRepo.UpdateUserByIdAsync(user);
            }
        }

        public Task UpdateUserByIdAsync(User user)
        {
            throw new NotImplementedException();
        }

    }
}

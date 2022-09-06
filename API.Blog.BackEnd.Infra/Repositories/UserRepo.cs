
using API.Blog.BackEnd.Domain.Entities;
using API.Blog.BackEnd.Domain.Interfaces;
using API.Blog.BackEnd.Infra.Contexts;
using MongoDB.Driver;

namespace API.Blog.BackEnd.Infra.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly IContext _context;

        public UserRepo()
        {
            _context = new Context();
        }

        public async Task CreateUserAsync(User user)
        {
            await _context.Users.InsertOneAsync(user);
        }

        public async Task<List<User>> DisplayAllUsersAsync()
        {
            var users = await _context.Users.FindAsync(user => true);
            return users.ToList();
        }

        public async Task<User> DisplayUserByIdAsync(string id)
        {
            var user = await _context.Users.Find(_ => _.Id == id).FirstOrDefaultAsync();
            return user;
        }

        public async Task UpdateUserByIdAsync(User user)
        {
            await _context.Users.ReplaceOneAsync(_ => _.Id == user.Id, user, new UpdateOptions { IsUpsert = true });
        }
        public async Task DeleteUserByIdAsync(string id)
        {
            await _context.Users.DeleteOneAsync(_ => _.Id == id);
        }
    }
}

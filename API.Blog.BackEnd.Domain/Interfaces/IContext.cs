
using API.Blog.BackEnd.Domain.Entities;
using MongoDB.Driver;

namespace API.Blog.BackEnd.Domain.Interfaces
{
    public interface IContext
    {
        public IMongoCollection<User> Users { get; }
        public IMongoCollection<Post> Posts { get; }
    }
}

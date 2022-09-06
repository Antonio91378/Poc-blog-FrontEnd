

using API.Blog.BackEnd.Domain.Entities;
using API.Blog.BackEnd.Domain.Interfaces;
using API.Blog.BackEnd.Utils;
using MongoDB.Driver;

namespace API.Blog.BackEnd.Infra.Contexts
{
    public class Context : IContext
    {

        public IMongoCollection<User> Users { get; }
        public IMongoCollection<Post> Posts { get; }

        public Context()
        {
            var client = new MongoClient(ApplicationSettings.GetMongoDBConnectionString());
            var DataBase = client.GetDatabase("Blog");
            Users = DataBase.GetCollection<User>("Users");
            Posts = DataBase.GetCollection<Post>("Posts");
        }
    }
}

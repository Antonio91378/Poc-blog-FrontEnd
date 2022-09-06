using API.Blog.BackEnd.Domain.Entities;
using API.Blog.BackEnd.Domain.Interfaces;
using API.Blog.BackEnd.Infra.Repositories;

namespace API.Blog.BackEnd.Service
{
    public class PostService : IPostService
    {
        private readonly IPostRepo _postRepo;

        public PostService()
        {
            _postRepo = new PostRepo();
        }

        public async Task CreatePostAsync(Post post)
        {
            await _postRepo.CreatePostAsync(post);
        }

        public async Task DeletePostByIdAsync(string id)
        {
            await _postRepo.DeletePostByIdAsync(id);
        }

        public async Task<List<Post>> DisplayAllPostsAsync()
        {
            var posts = await _postRepo.DisplayAllPostsAsync();
            return posts;
        }

        public async Task<Post> DisplayPostByIdAsync(string id)
        {
            var post = await _postRepo.DisplayPostByIdAsync(id);
            return post;
        }

    }
}

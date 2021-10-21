using Social_network.Models;
using System.Collections.Generic;
using System.Linq;

namespace Social_network.Services
{
    public static class PostService
    {
        static List<Post> Posts { get; }
        static int nextId = 2;
        static PostService()
        {
            Posts = new List<Post>
            {
                new Post { Id = 1, Title = "Post's title", Content = "This is post's content" },
            };
        }

        public static List<Post> GetAll() {
            return Posts;
        }
        public static Post GetById(int id) {
            return Posts.FirstOrDefault(p => p.Id == id);
        }
        public static void Create(Post post) {
            post.Id = nextId++;
            Posts.Add(post);
        }
        public static void Update(Post post) {
            var i = Posts.FindIndex(p => p.Id == post.Id);
            if (i == -1) {
                return;
            }

            Posts[i] = post;

        }
        public static void Delete(int id) {
            var post = GetById(id);
            if (post is null) {
                return;
            }
            Posts.Remove(post);
        }
    }
}
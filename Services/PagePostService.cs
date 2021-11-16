using Social_network.Models;
using System.Collections.Generic;
using System.Linq;

namespace Social_network.Services
{
    public static class PagePostService
    {
        static List<PagePost> PagePosts { get; }
        static int nextId = 2;
        static PagePostService()
        {
            PagePosts = new List<PagePost>
            {
                new PagePost { 
                    Id = 1, 
                    PageId = 1, 
                    Content = "abcxyz", 
                    CreatedAt = System.DateTime.UtcNow
                 }
            };
        }

        public static List<PagePost> GetAll() => PagePosts;

        public static PagePost Get(int id) => PagePosts.FirstOrDefault(p => p.Id == id);

        public static void Add(PagePost pagepost)
        {
            pagepost.Id = nextId++;
            PagePosts.Add(pagepost);
        }

        public static void Delete(int id)
        {
            var pagepost = Get(id);
            if(pagepost is null)
                return;

            PagePosts.Remove(pagepost);
        }

        public static void Update(PagePost pagepost)
        {
            var index = PagePosts.FindIndex(p => p.Id == pagepost.Id);
            if(index == -1)
                return;

            PagePosts[index] = pagepost;
        }
    }
}
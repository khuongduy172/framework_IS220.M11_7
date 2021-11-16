using Social_network.Models;
using System.Collections.Generic;
using System.Linq;

namespace Social_network.Services
{
    public static class PageMxhService
    {
        static List<PageMxh> PageMxhs { get; }
        static int nextId = 2;
        static PageMxhService()
        {
            PageMxhs = new List<PageMxh>
            {
                new PageMxh { 
                    Id = 1, 
                    OwnerId = 1,
                    DescriptionMxh = "abc",
                    NamePage = "ABC",
                    Avatar = "/",
                    CoverImage = "/",
                    CreatedAt = System.DateTime.UtcNow, 
                    UpdateAt = System.DateTime.UtcNow, 
                    IsDeleted = 0,
                 }
            };
        }

        public static List<PageMxh> GetAll() => PageMxhs;

        public static PageMxh Get(int id) => PageMxhs.FirstOrDefault(p => p.Id == id);

        public static void Add(PageMxh pageMxh)
        {
            pageMxh.Id = nextId++;
            PageMxhs.Add(pageMxh);
        }

        public static void Delete(int id)
        {
            var pageMxh = Get(id);
            if(pageMxh is null)
                return;

            PageMxhs.Remove(pageMxh);
        }

        public static void Update(PageMxh pageMxh)
        {
            var index = PageMxhs.FindIndex(p => p.Id == pageMxh.Id);
            if(index == -1)
                return;

            PageMxhs[index] = pageMxh;
        }
    }
}
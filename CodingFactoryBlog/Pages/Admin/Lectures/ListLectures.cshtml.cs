using CodingFactoryBlog.DATA;
using CodingFactoryBlog.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CodingFactoryBlog.Pages.Admin.Lectures
{
    public class ListLecturesModel : PageModel
    {
        private readonly CodingFactoryBlogDbContext codingFactoryBlogDbContext;

        public List<Lecture> Lectures { get; set; } // store the DbContext data

        public ListLecturesModel(CodingFactoryBlogDbContext codingFactoryBlogDbContext)
        {
            this.codingFactoryBlogDbContext = codingFactoryBlogDbContext;
        }
        public async Task OnGet()
        {
            // import the toList from EF 
           Lectures =  await codingFactoryBlogDbContext.Lectures.ToListAsync();





        }
    }
}

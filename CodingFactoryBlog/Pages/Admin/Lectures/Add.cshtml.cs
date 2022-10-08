using CodingFactoryBlog.DATA;
using CodingFactoryBlog.Models.Domain;
using CodingFactoryBlog.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodingFactoryBlog.Pages.Admin.Lectures
{
    public class AddModel : PageModel
    {
        private readonly CodingFactoryBlogDbContext codingFactoryBlogDbContext;

        [BindProperty]
        public AddLecture AddLectureRequest { get; set; }

        public AddModel(CodingFactoryBlogDbContext codingFactoryBlogDbContext)
        {
            this.codingFactoryBlogDbContext = codingFactoryBlogDbContext;
        }


        public void OnGet()
        {
        }

        // read the values coming from the form
        public async Task<IActionResult> OnPost()
        {


            var lecture = new Lecture()
            {
                Header = AddLectureRequest.Header,
                PageTitle = AddLectureRequest.PageTitle,
                Content = AddLectureRequest.Content,
                ShortDescription = AddLectureRequest.ShortDescription,
                ImageUrl = AddLectureRequest.ImageUrl,
                UniqueUrl = AddLectureRequest.UniqueUrl,
                PublishedDate = AddLectureRequest.PublishedDate,
                Author = AddLectureRequest.Author,
                Visible = AddLectureRequest.Visible,
            };
            // async to DbContext;

           await codingFactoryBlogDbContext.Lectures.AddAsync(lecture);
           await codingFactoryBlogDbContext.SaveChangesAsync();

            // go to list all 

            return RedirectToPage("/Admin/Lectures/ListLectures");

        }
    }
}

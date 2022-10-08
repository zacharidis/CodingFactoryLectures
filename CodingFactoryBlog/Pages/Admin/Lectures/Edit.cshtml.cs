using CodingFactoryBlog.DATA;
using CodingFactoryBlog.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodingFactoryBlog.Pages.Admin.Lectures
{
    public class EditModel : PageModel
    {
        private readonly CodingFactoryBlogDbContext codingFactoryBlogDbContext;

        [BindProperty]
        public  Lecture SelectedLecture { get; set; }
        public EditModel(CodingFactoryBlogDbContext codingFactoryBlogDbContext)
        {
            this.codingFactoryBlogDbContext = codingFactoryBlogDbContext;
        }
        public async Task  OnGet(Guid id)
        {

           SelectedLecture =  await codingFactoryBlogDbContext.Lectures.FindAsync(id);
            
          
        }


        public async Task<IActionResult> OnPostUpdate()
        {
            var ExistingLecture = await codingFactoryBlogDbContext.Lectures.FindAsync(SelectedLecture.Id);

            if (ExistingLecture != null)
            {
                ExistingLecture.Header = SelectedLecture.Header;
                ExistingLecture.PageTitle = SelectedLecture.PageTitle;
                ExistingLecture.Content = SelectedLecture.Content;
                ExistingLecture.ShortDescription = SelectedLecture.ShortDescription;
                ExistingLecture.ImageUrl = SelectedLecture.ImageUrl;
                ExistingLecture.UniqueUrl = SelectedLecture.UniqueUrl;
                ExistingLecture.PublishedDate = SelectedLecture.PublishedDate;
                ExistingLecture.Author = SelectedLecture.Author;
                ExistingLecture.Visible = SelectedLecture.Visible;


            }

            await codingFactoryBlogDbContext.SaveChangesAsync();
            // save changes

            return RedirectToPage("/Admin/Lectures/ListLectures");

        }

        
        public async Task<IActionResult> OnPostDelete()
        {
            var ExistingLecture = await codingFactoryBlogDbContext.Lectures.FindAsync(SelectedLecture.Id);

            if (ExistingLecture != null )
            {

                codingFactoryBlogDbContext.Lectures.Remove(ExistingLecture);
             await   codingFactoryBlogDbContext.SaveChangesAsync();

                return RedirectToPage("/Admin/Lectures/ListLectures");
            }

            return Page();
        }
    }
}

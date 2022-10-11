using CodingFactoryBlog.Models.Domain;
using CodingFactoryBlog.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodingFactoryBlog.Pages.Admin.Lectures
{
    public class CurrentLectureModel : PageModel
    {
        private readonly ILectureRepository lectureRepository;

        public Lecture lecture { get; set; }
        public CurrentLectureModel(ILectureRepository lectureRepository)
        {
            this.lectureRepository = lectureRepository;
        }
        public async Task<IActionResult> OnGet(string UniqueUrl)
        {

         lecture = await lectureRepository.GetAsync(UniqueUrl);

            return Page();


        }
    }
}

using CodingFactoryBlog.Models.Domain;
using CodingFactoryBlog.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodingFactoryBlog.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ILectureRepository lectureRepository;

        
        public List<Lecture> Lectures { get; set; }
        public IndexModel(ILogger<IndexModel> logger , ILectureRepository lectureRepository)
        {
            _logger = logger;
            this.lectureRepository = lectureRepository;
        }

        public async Task<IActionResult> OnGet()
        {
           //convert to a list and populate the tb
          Lectures = ( await lectureRepository.GetAllAsync()).ToList();
            return Page();

        }
    }
}
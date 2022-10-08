using CodingFactoryBlog.DATA;
using CodingFactoryBlog.Models.Domain;
using CodingFactoryBlog.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CodingFactoryBlog.Pages.Admin.Lectures
{
    public class ListLecturesModel : PageModel
    {
      
        private readonly ILectureRepository lectureRepository;

        public List<Lecture> Lectures { get; set; } // store the DbContext data

        public ListLecturesModel(ILectureRepository lectureRepository)
        {
           
            this.lectureRepository = lectureRepository;
        }
        public async Task OnGet()
        {
            // import the toList from EF 
            Lectures = (await lectureRepository.GetAllAsync())?.ToList();





        }
    }
}

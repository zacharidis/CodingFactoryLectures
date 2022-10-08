using CodingFactoryBlog.DATA;
using CodingFactoryBlog.Models.Domain;
using CodingFactoryBlog.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.InteropServices;

namespace CodingFactoryBlog.Pages.Admin.Lectures
{
    public class EditModel : PageModel
    {
        private readonly ILectureRepository lectureRepository;

        [BindProperty]
        public  Lecture SelectedLecture { get; set; }
        public EditModel(ILectureRepository lectureRepository)
        {
            this.lectureRepository = lectureRepository;
        }
        public async Task  OnGet(Guid id)
        {

           SelectedLecture =  await lectureRepository.GetAsync(id);
            
          
        }


        public async Task<IActionResult> OnPostUpdate()
        {
          
            await lectureRepository.UpdateAsync(SelectedLecture);

            return RedirectToPage("/Admin/Lectures/ListLectures");

        }

        
        public async Task<IActionResult> OnPostDelete()
        {

          var deleted =  await lectureRepository.DeleteAsync(SelectedLecture.Id);

            if(deleted)
            {
                return RedirectToPage("/Admin/Lectures/ListLectures");
            }

            return Page();




        }
    }
}

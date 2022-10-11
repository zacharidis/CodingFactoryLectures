using CodingFactoryBlog.DATA;
using CodingFactoryBlog.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CodingFactoryBlog.Repositories
{
    public class LectureRepository : ILectureRepository
    {
        private readonly CodingFactoryBlogDbContext codingFactoryBlogDbContext;

        public LectureRepository(CodingFactoryBlogDbContext codingFactoryBlogDbContext)

        {
            this.codingFactoryBlogDbContext = codingFactoryBlogDbContext;
        }


        public async Task<Lecture> AddAsync(Lecture lecture)
        {


            await codingFactoryBlogDbContext.Lectures.AddAsync(lecture);
            await codingFactoryBlogDbContext.SaveChangesAsync();
            return lecture;





        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var ExistingLecture = await codingFactoryBlogDbContext.Lectures.FindAsync(id);

            if(ExistingLecture != null)
            {
                codingFactoryBlogDbContext.Lectures.Remove(ExistingLecture);
                codingFactoryBlogDbContext.SaveChangesAsync().Wait();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Lecture>> GetAllAsync()
        {
           return await codingFactoryBlogDbContext.Lectures.ToListAsync();
        }

        public async Task<Lecture> GetAsync(Guid id)
        {
         return await codingFactoryBlogDbContext.Lectures.FindAsync(id);

        }

        public async Task<Lecture> GetAsync(string url)
        {
            return await codingFactoryBlogDbContext.Lectures.FirstOrDefaultAsync(x => x.UniqueUrl == url);
        }

        public async Task<Lecture> UpdateAsync(Lecture lecture)
        {
            var ExistingLecture = await codingFactoryBlogDbContext.Lectures.FindAsync(lecture.Id);

            if (ExistingLecture != null)
            {
                ExistingLecture.Header = lecture.Header;
                ExistingLecture.PageTitle = lecture.PageTitle;
                ExistingLecture.Content = lecture.Content;
                ExistingLecture.ShortDescription = lecture.ShortDescription;
                ExistingLecture.ImageUrl = lecture.ImageUrl;
                ExistingLecture.UniqueUrl = lecture.UniqueUrl;
                ExistingLecture.PublishedDate = lecture.PublishedDate;
                ExistingLecture.Author = lecture.Author;
                ExistingLecture.Visible = lecture.Visible;


            }

            await codingFactoryBlogDbContext.SaveChangesAsync();
            // save changes

            return ExistingLecture;
        }
    }
}

using CodingFactoryBlog.Models.Domain;

namespace CodingFactoryBlog.Repositories
{
    public interface ILectureRepository
    {

        Task<IEnumerable<Lecture>> GetAllAsync();
        Task<Lecture> GetAsync(Guid id);

        Task<Lecture> GetAsync(string url);

        Task<Lecture> AddAsync(Lecture lecture);
        Task<Lecture> UpdateAsync(Lecture lecture);     

        Task<bool> DeleteAsync(Guid id);






    }
}

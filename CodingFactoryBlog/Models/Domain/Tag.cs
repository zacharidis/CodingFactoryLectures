namespace CodingFactoryBlog.Models.Domain
{

    /// <summary>
    /// 
    ///  Class Tag code 
    ///  written by Georgios Zacharidis 
    ///  as a part of the final CF project
    /// 
    /// </summary>
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid LectureId { get; set; } 

    }
}

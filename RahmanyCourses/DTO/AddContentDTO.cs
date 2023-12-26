using RahmanyCourses.Core.Enums;

namespace RahmanyCourses.Persentation.DTO
{
    public class AddContentDTO
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public ContentType Type { get; set; }
        public IFormFile Content { get; set; }
        public int OrderInCourse { get; set; }
    }
}

namespace RahmanyCourses.Persentation.DTO
{
    public class UpdateContentDTO
    {
        public int CourseID { get; set; }
        public int ContentID { get; set; }
        public string Title { get; set; }
        public IFormFile Content { get; set; }
    }
}

using RahmanyCourses.Core.Enums;

namespace RahmanyCourses.Core.Entities
{
    public class Content : BaseEntity
    {        
        public int CourseID { get; set; }
        public string Title { get; set; }
        public ContentType Type { get; set; }
        public string URL { get; set; }
        public int OrderInCourse { get; set; }
        public bool IsWatched { get; set; } = false;

        // Navigation property
        public virtual Course Course { get; set; }
        public virtual ICollection<ContentReport> ContentReports { get; set; }
    }
}

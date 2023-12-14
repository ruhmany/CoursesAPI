namespace Core.Entities
{
    public class ContentReport
    {
        public int ContentID { get; set; }
        public int UserID { get; set; }
        public string ReportMessage { get; set; }
        public virtual Content Content { get; set; }
        public virtual User User { get; set; }
    }
}

namespace RahmanyCourses.Core.Entities
{

    public class RefreshToken : BaseEntity
    {        
        public string Token { get; set; }
        public DateTime ExpiredOn { get; set; }
        public bool IsValid => DateTime.Now < ExpiredOn;
        public DateTime CreatedOn { get; set; }
        public DateTime? RevokeOn { get; set; }
        public bool IsActive => RevokeOn == null && !IsValid;
    }
}

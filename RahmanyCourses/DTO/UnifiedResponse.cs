namespace RahmanyCourses.Persentation.DTO
{
    public class UnifiedResponse<T>
    {
        public string Status { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }

        public static UnifiedResponse<T> Success(T data, string message = "Operation successful", int code = 200)
        {
            return new UnifiedResponse<T>
            {
                Status = "success",
                Code = code,
                Message = message,
                Data = data,
                Errors = new List<string>()
            };
        }
        public static UnifiedResponse<T> Error(string message, int code = 500, List<string> errors = null)
        {
            return new UnifiedResponse<T>
            {
                Status = "error",
                Code = code,
                Message = message,
                Data = default,
                Errors = errors ?? new List<string>()
            };
        }
    }
}

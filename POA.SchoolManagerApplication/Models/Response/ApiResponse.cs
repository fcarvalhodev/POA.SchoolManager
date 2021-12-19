namespace POA.SchoolManagerApplication.Models
{
    public class ApiResponse<T> where T : class
    {
        public string Message { get; set; }
        public string Help { get; set; }
        public bool Success { get; set; }
        public ApiResult<T> Result { get; set; }
    }
}

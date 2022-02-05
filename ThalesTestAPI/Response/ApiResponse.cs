namespace ThalesTestAPI.CustomEntities
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
        }
        public string status { get; set; }
        public int code { get; set; }
        public T Data { get; set; }
        public string message { get; set; }
    }
}

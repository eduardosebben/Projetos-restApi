namespace RelatoriosApi.Models
{
    public record ApiResponse<T> : ApiResponsePadrao
    {
        public ApiResponse(T data)
        {
            Data = data;
            Success = true;
        }

        public ApiResponse(Exception exception) : base(exception)
        {
        }

        public T Data { get; set; }
    }
}

namespace RelatoriosApi.Models
{
    public record ApiResponsePadrao
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }

        public ApiResponsePadrao()
        {

        }

        public ApiResponsePadrao(Exception exception)
        {
            Success = false;
            ErrorMessage = exception.Message;
        }
    }
}

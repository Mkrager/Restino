namespace GloboTicket.TicketManagement.Application.Responses
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Success = true;
        }
        public BaseResponse(string message)
        {
            Success = true;
            ErrorText = message;
        }

        public BaseResponse(string message, bool success)
        {
            Success = success;
            ErrorText = message;
        }

        public bool Success { get; set; }
        public string ErrorText { get; set; } = string.Empty;
        public List<string>? ValidationErrors { get; set; }
    }
}

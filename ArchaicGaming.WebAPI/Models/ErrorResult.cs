namespace ArchaicGaming.WebAPI.Models
{
    public class ErrorResult
    {
        public ErrorResult(int errorCode, string message)
        {
            ErrorCode = errorCode;
            Message = message;
        }
        public int ErrorCode { get; private set; }
        public string Message { get; private set; }
    }
}
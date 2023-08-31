using System.Net;

namespace B3.DesafioCalculo.Shared.DTO
{
    public class BaseResponseDto<TData> where TData : class
    {
        public BaseResponseDto(TData data, bool success, int statusCode, IEnumerable<string> messages)
        {
            Success = success;
            Messages = messages ?? new List<string>();
            Data = data;
            StatusCode = statusCode;
        }

        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public TData? Data { get; set; }
        public IEnumerable<string>? Messages { get; set; }
    }
}

using System.Net;

namespace B3.DesafioCalculo.Shared.DTO
{
    public class BaseResponseDTO<TData> where TData : class
    {
        public BaseResponseDTO() { }

        public BaseResponseDTO(TData data, bool success, HttpStatusCode statusCode, IEnumerable<string> messages = null!)
            => new BaseResponseDTO<TData>(data, success, (int)statusCode, messages);

        public BaseResponseDTO(TData data, bool success, int statusCode, IEnumerable<string> messages = null)
        {
            this.Success = success;
            this.Messages = messages ?? new List<string>();
            this.Data = data;
            this.StatusCode = statusCode;
        }

        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public TData Data { get; set; }
        public IEnumerable<string> Messages { get; set; }
    }
}

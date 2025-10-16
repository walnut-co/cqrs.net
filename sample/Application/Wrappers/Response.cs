using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CQRS.Sample.Wrappers
{
    public class Response<T>
    {
        public Response()
        {
        }
        public Response(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }
        
        public Response(string message, bool isSuccess)
        {
            Succeeded = isSuccess;
        }

        public Response(bool isSuccess, T data)
        {
            Succeeded = isSuccess;
            Message = null;
            Data = data;
        }

        [JsonPropertyName("succeeded")]
        public bool Succeeded { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("errors")]
        public List<string> Errors { get; set; }

        [JsonPropertyName("data")]
        public T Data { get; set; }
    }
}

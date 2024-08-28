using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sQpets_Backend.Notifications;

namespace sQpets_Backend.DTO
{
    public class ReturnDTO<T>
    {
        public int StatusCode { get; private set; }
        public string Message { get; private set; }
        public T? Data { get; private set; }
        public IReadOnlyCollection<Notification>? Error { get; private set; }

        // Retorno para sucesso
        public ReturnDTO(T? data, string message, int status)
        {
            StatusCode = status;
            Message = message;
            Data = data;
            Error = null;
        }

        //Retorno para erro com objeto
        public ReturnDTO(IReadOnlyCollection<Notification> errors, string message, int status)
        {
            Data = default;
            StatusCode = status;
            Message = message;
            Error = errors;
        }

        //Retorno erro sem Objeto
        public ReturnDTO(string message, int status)
        {
            Message = message;
            StatusCode = status;
            Data = default;
            Error = default;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelebuTinyUrlDotNetFramework4.Models.APIContracts
{
    public class GenericApiResponse<T>
    {
        public string Message { get; set; }
        public int Success { get; set; }
        public int StatusCode { get; set; }
        public T Payload { get; set; }
        public static GenericApiResponse<T> Successful(T payload, string message)
        {
            return new GenericApiResponse<T>
            {
                Success = 0,
                Message = message,
                StatusCode = 200,
                Payload = payload,
            };
        }
        public static GenericApiResponse<T> Successful(string message)
        {
            return new GenericApiResponse<T>
            {
                Success = 0,
                Message = message,
                StatusCode = 200
            };
        }
        public static GenericApiResponse<T> Failure(T payload, string message, int errorCode)
        {
            return new GenericApiResponse<T>
            {
                Success = errorCode,
                Message = message,
                StatusCode = 200,
                Payload = payload
            };
        }
        public static GenericApiResponse<T> Failure(string message, int errorCode)
        {
            return new GenericApiResponse<T>
            {
                Success = errorCode,
                Message = message,
                StatusCode = 200,
            };
        }

    }
}
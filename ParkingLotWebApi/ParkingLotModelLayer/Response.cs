using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ParkingLotModelLayer
{
    public class Response
    {
        public HttpStatusCode statusCode { get; }
        public string message { get; }
        public object data { get; }
        public Response(HttpStatusCode statusCode, string message, object data)
        {
            this.statusCode = statusCode;
            this.message = message;
            this.data = data;
        } 
    }
}

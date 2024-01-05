using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }

    //public enum HttpStatusCode
    //{
    //    OK=200,
    //    bad=400
    //}
}

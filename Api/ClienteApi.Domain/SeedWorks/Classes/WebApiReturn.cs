using System;

namespace ClienteApi.Domain.SeedWorks.Classes
{
   

    public struct WebApiReturn
    {
        public bool TransactionExecute { get; set; }
        public string RunBy { get; set; }
        public DateTime ProcessorAt { get; set; }
        public int StatusCode { get; set; }
        public int Messagecode { get; set; }
        public string MessageTitle { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public object Errors { get; set; }
        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public double ProcessingTime { get; set; }
    }

}

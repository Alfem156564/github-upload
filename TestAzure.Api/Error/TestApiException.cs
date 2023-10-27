namespace TestAzure.Api.Error
{
    using Common.Enumerations;
    using System;
    using System.Net;

    internal class TestApiException : Exception
    {
        public ErrorCodes ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public HttpStatusCode StatusCode { get; set; }

    }
}

﻿namespace TestAzure.Api.Definition.Error
{
    using Common.Enumerations;
    using System;
    using System.Net;

    public class ApiException : Exception
    {
        public ErrorCodes ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}

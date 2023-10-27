namespace TestAzure.Api.Helpers
{
    using Common.Enumerations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using TestAzure.Api.Definition;
    using TestAzure.Api.Error;

    internal class Validator<T>
    {
        private readonly T request;

        private readonly List<Tuple<Func<T, bool>, ErrorCodes, string, HttpStatusCode>> validations =
            new List<Tuple<Func<T, bool>, ErrorCodes, string, HttpStatusCode>>();

        private readonly List<Func<HttpStatusCode>> validators = new List<Func<HttpStatusCode>>();

        public Validator(T request)
        {
            this.request = request;
        }

        public Validator<T> AddValidator(Func<HttpStatusCode> validator)
        {
            validators.Add(validator);
            return this;
        }

        public Validator<T> AddBadRequestValidation(Func<T, bool> isInvalid, ErrorCodes errorCode, string message)
        {
            return AddValidation(
                isInvalid,
                errorCode,
                message,
                HttpStatusCode.BadRequest);
        }

        public Validator<T> AddNotFoundValidation(Func<T, bool> isInvalid, ErrorCodes errorCode, string message)
        {
            return AddValidation(isInvalid, errorCode, message, HttpStatusCode.NotFound);
        }

        public Validator<T> AddConflictValidation(Func<T, bool> isInvalid, ErrorCodes errorCode, string message)
        {
            return AddValidation(isInvalid, errorCode, message, HttpStatusCode.Conflict);
        }

        public Validator<T> AddUnprocessableEntityValidation(Func<T, bool> isInvalid, ErrorCodes errorCode, string message)
        {
            return AddValidation(isInvalid, errorCode, message, HttpStatusCode.UnprocessableEntity);
        }

        public Validator<T> AddBadGatewayValidation(Func<T, bool> isInvalid, ErrorCodes errorCode, string message)
        {
            return AddValidation(isInvalid, errorCode, message, HttpStatusCode.BadGateway);
        }

        public Validator<T> AddForbiddenValidation(Func<T, bool> isInvalid, ErrorCodes errorCode, string message)
        {
            return AddValidation(isInvalid, errorCode, message, HttpStatusCode.Forbidden);
        }

        private Validator<T> AddValidation(Func<T, bool> isInvalid, ErrorCodes errorCode, string message, HttpStatusCode statusCode)
        {
            validations.Add(new Tuple<Func<T, bool>, ErrorCodes, string, HttpStatusCode>(isInvalid, errorCode, message, statusCode));
            return this;
        }

        public void Validate()
        {
            var validationsResult = validations
                .Where(validation => validation.Item1(request))
                .Select(validation =>
                    new TestApiException
                    {
                        ErrorCode = validation.Item2,
                        ErrorMessage = validation.Item3,
                        StatusCode = validation.Item4
                    })
                .FirstOrDefault();

            if (validationsResult != null)
            {
                throw validationsResult;
            }
        }

        public ErrorDefinition GetErrorDefinition()
        {
            var validationsResult = validations
                .Where(validation => validation.Item1(request))
                .Select(validation =>
                {
                    var error = new ErrorDefinition
                    {
                        Code = validation.Item2.ToString(),
                        Message = validation.Item3
                    };

                    return error;
                })
                .FirstOrDefault();

            if (validationsResult != null) return validationsResult;

            return null;
        }

        public Validator<T> AddUnauthorizedRequestValidation(Func<T, bool> isInvalid, ErrorCodes errorCode, string message)
        {
            return AddValidation(isInvalid, errorCode, message, HttpStatusCode.Unauthorized);
        }
    }
}
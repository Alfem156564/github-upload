namespace Test.Api.Helpers
{
    using Common.Enumerations;
    using Common.Models;
    using Data.Models.Entities;
    using Microsoft.AspNetCore.Mvc;
    using Test.Api.Definition;

    public class ValidationHelpers
    {

        #region UserType
        public static IActionResult GetUserTypeIdValidation(string userTypeId)
        {
            var validator = new Validator<string>(userTypeId)
                .AddBadRequestValidation(request =>
                    string.IsNullOrWhiteSpace(request),
                    ErrorCodes.InvalidUserTypeId,
                    "El id del tipo usuario no puede ser nulo o vacio");

            return validator.Validate();
        }

        public static IActionResult GetUserTypeNullValidation(UserTypeEntity request, string id)
        {
            var validator = new Validator<UserTypeEntity>(request)
                .AddBadRequestValidation(request =>
                    request == null,
                    ErrorCodes.InvalidUserTypeRequest,
                    $"El tipo usuario con id {id} no existe");

            return validator.Validate();
        }

        public static IActionResult GetUserTypeValidation(UserTypeDefinition request)
        {
            var validator = new Validator<UserTypeDefinition>(request)
                .AddBadRequestValidation(request =>
                    request == null,
                    ErrorCodes.InvalidUserTypeRequest,
                    "El tipo usuario no puede ser null")
                .AddBadRequestValidation(request =>
                        string.IsNullOrWhiteSpace(request.Name),
                    ErrorCodes.InvalidUserTypeName,
                    "El nombre del tipo usuario no puede ser null o vacio");

            return validator.Validate();
        }

        public static IActionResult CreateUserTypesValidation(ManagerResult<UserTypeEntity> result,
            string userTypeName,
            string userTypeId)
        {
            if (!result.DidSucceed)
            {
                var validator = new Validator<ManagerResult<UserTypeEntity>>(result)
                                .AddBadRequestValidation(request =>
                                    request.ErrorCode == ErrorCodes.UserTypeNameAlreadyExists,
                                    ErrorCodes.UserTypeNameAlreadyExists,
                                    $"El nombre {userTypeName} ya existe")
                                .AddBadRequestValidation(request =>
                                    request.ErrorCode == ErrorCodes.UserTypeNotFound,
                                    ErrorCodes.UserTypeNotFound,
                                    $"No se encontro el tipo usuario con id '{userTypeId}'")
                                .AddUnprocessableEntityValidation(request =>
                                    !request.DidSucceed,
                                    ErrorCodes.Unknown,
                                    "Error inesperado");

                return validator.Validate();
            }
            return null;

        }
        #endregion
    }
}

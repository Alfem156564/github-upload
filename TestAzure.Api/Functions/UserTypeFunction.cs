using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Core.Contracts;
using TestAzure.Api.Helpers;
using TestAzure.Api.Definition;

namespace TestAzure.Api.Functions
{
    public class UserTypeFunction
    {
        private readonly IUserTypeManager _userTypeManager;

        public UserTypeFunction(
            IUserTypeManager userTypeManager)
        {
            _userTypeManager = userTypeManager;
        }

        [FunctionName("GetUserTypes")]
        public async Task<IActionResult> GetUserTypes(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "get",
                Route = ApiRoutes.TipoUsuarioUsuario)] HttpRequest request)
        {
            var userTypes = _userTypeManager
                .GetUserTypes();

            return new OkObjectResult(userTypes
                .ToListDefinition());
        }

        [FunctionName("GetUserTypesDisabled")]
        public async Task<IActionResult> GetUserTypesDisabled(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "get",
                Route = ApiRoutes.TipoUsuarioUsuarioDisabled)] HttpRequest request)
        {
            var userTypes = _userTypeManager
                .GetUserTypesDisabled();

            return new OkObjectResult(userTypes
                .ToListDefinition());
        }

        [FunctionName("GetUserTypeById")]
        public async Task<IActionResult> GetUserTypeById(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "get",
                Route = ApiRoutes.TipoUsuarioUsuarioId)] HttpRequest request,
            string id)
        {
            var validation = ValidationHelpers
                .GetUserTypeIdValidation(id);

            if (validation != null)
            {
                return validation;
            }

            var userType = _userTypeManager
                .GetUserTypeById(id);


            validation = ValidationHelpers
               .GetUserTypeNullValidation(userType,
               id);

            if (validation != null)
            {
                return validation;
            }

            return new OkObjectResult(userType
                .ToDefinition());
        }

        [FunctionName("AddUserType")]
        public async Task<IActionResult> AddUserType(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "post",
                Route = ApiRoutes.TipoUsuarioUsuario)] HttpRequest request)
        {
            var userTypeDefinition = await request
            .GetRequestBodyAsync<UserTypeDefinition>()
            .ConfigureAwait(continueOnCapturedContext: false);

            var validation = ValidationHelpers
                .GetUserTypeValidation(userTypeDefinition);

            if (validation != null)
            {
                return validation;
            }

            var userType = await _userTypeManager
                .CreateUserTypeAsync(userTypeDefinition.Name, "system");

            validation = ValidationHelpers
               .CreateUserTypesValidation(userType,
               userTypeDefinition.Name,
               null);

            if (validation != null)
            {
                return validation;
            }

            return new OkObjectResult(userType.Value
                .ToDefinition());
        }

        [FunctionName("UpdateUserType")]
        public async Task<IActionResult> UpdateUserType(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "post",
                Route = ApiRoutes.TipoUsuarioUsuarioId)] HttpRequest request,
            string id)
        {
            var userTypeDefinition = await request
            .GetRequestBodyAsync<UserTypeDefinition>()
            .ConfigureAwait(continueOnCapturedContext: false);

            var validation = ValidationHelpers
                .GetUserTypeIdValidation(id);

            if (validation != null)
            {
                return validation;
            }

            validation = ValidationHelpers
                .GetUserTypeValidation(userTypeDefinition);

            if (validation != null)
            {
                return validation;
            }

            var userType = await _userTypeManager
                .UpdateUserTypeAsync(id, "system", userTypeDefinition.Name);

            validation = ValidationHelpers
               .CreateUserTypesValidation(userType,
               userTypeDefinition.Name,
               id);

            if (validation != null)
            {
                return validation;
            }

            return new OkObjectResult(userType.Value
                .ToDefinition());
        }

        [FunctionName("DeleteUserType")]
        public async Task<IActionResult> DeleteUserType(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "delete",
                Route = ApiRoutes.TipoUsuarioUsuarioId)] HttpRequest request,
            string id)
        {
            var validation = ValidationHelpers
                .GetUserTypeIdValidation(id);

            if (validation != null)
            {
                return validation;
            }

            var userType = await _userTypeManager
                .DisabledUserTypeAsync(id, "system");

            validation = ValidationHelpers
               .CreateUserTypesValidation(userType,
               null,
               id);

            if (validation != null)
            {
                return validation;
            }

            return new OkObjectResult(userType.Value
                .ToDefinition());
        }
    }
}

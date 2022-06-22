using Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Test.Api.Definition;
using Test.Api.Helpers;

namespace Test.Api.Controllers
{
    [Route("api/usertype")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypeManager userTypeManager;

        public UserTypeController(
            IUserTypeManager userTypeManager)
        {
            this.userTypeManager = userTypeManager;
        }

        [HttpGet]
        public IActionResult GetUserTypes()
        {
            var userTypes = userTypeManager
                .GetUserTypes();

            return new OkObjectResult(userTypes
                .ToListDefinition());
        }

        [HttpGet("disabled")]
        public IActionResult GetUserTypesDisabled()
        {
            var userTypes = userTypeManager
                .GetUserTypesDisabled();

            return new OkObjectResult(userTypes
                .ToListDefinition());
        }

        [HttpGet("id/{id}")]
        public IActionResult GetUserTypeById(string id)
        {
            var validation = ValidationHelpers
                .GetUserTypeIdValidation(id);

            if (validation != null)
            {
                return validation;
            }

            var userType = userTypeManager
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

        [HttpPost]
        public async Task<IActionResult> AddUserType(UserTypeDefinition userTypeDefinition)
        {
            var validation = ValidationHelpers
                .GetUserTypeValidation(userTypeDefinition);

            if (validation != null)
            {
                return validation;
            }

            var userType = await userTypeManager
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

        [HttpPost("id/{id}")]
        public async Task<IActionResult> UpdateUserType(string id, 
            UserTypeDefinition userTypeDefinition)
        {
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

            var userType = await userTypeManager
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

        [HttpDelete("id/{id}")]
        public async Task<IActionResult> DeleteUserType(string id)
        {
            var validation = ValidationHelpers
                .GetUserTypeIdValidation(id);

            if (validation != null)
            {
                return validation;
            }

            var userType = await userTypeManager
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

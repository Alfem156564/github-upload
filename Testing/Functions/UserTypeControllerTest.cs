namespace Testing.Functions
{
    using Common.Enumerations;
    using Data.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using System;
    using System.Collections.Generic;
    using Test.Api.Controllers;
    using Test.Api.Definition;
    using Testing.Functions.Base;
    using Xunit;

    public class UserTypeContrillerTest : FunctionsTestBase
    {
        private UserTypeController functionToTest;

        public UserTypeContrillerTest()
        {
            databaseContextMock
                .Setup(context => context.UserTypes)
                .Returns(TestDataFactory.GetUserTypeMock().Object);

            functionToTest = new UserTypeController(userTypeManagerProvider);
        }

        [Theory]
        [InlineData(null, ErrorCodes.InvalidUserTypeId)]
        [InlineData("", ErrorCodes.InvalidUserTypeId)]
        [InlineData(" ", ErrorCodes.InvalidUserTypeId)]
        public void GetUserTypeById_ShouldBeBadRequest(string userTypeId, ErrorCodes error)
        {
            var result = functionToTest
                .GetUserTypeById( userTypeId);

            Assert.True(result.GetType() == typeof(BadRequestObjectResult), "Assert result is BadRequestObjectResult type.");

            var response = (ErrorDefinition)((BadRequestObjectResult)result).Value;

            Assertions.ErrorDefinitionIsNotNullOrEmpty(response);

            Assert.True(
                error.ToString().Equals(response.Code, StringComparison.InvariantCultureIgnoreCase),
                $"Assert ErrorDefinition.Code is {error}.");
        }

        [Fact]
        public void GetUserTypeById_ShouldBeSuccessful()
        {
            var result = functionToTest
                .GetUserTypeById(TestDataFactory.ValidUserTypeId);

            Assert.NotNull(result);
            Assert.True(result.GetType() == typeof(OkObjectResult), "Assert is OkObjectResult type.");

            var definition = (UserTypeDefinition)((OkObjectResult)result).Value;

            Assert.NotNull(definition);
        }

        [Fact]
        public void GetUserTypes_ShouldBeSuccessful()
        {
            var result = functionToTest
                .GetUserTypes();

            Assert.NotNull(result);
            Assert.True(result.GetType() == typeof(OkObjectResult), "Assert is OkObjectResult type.");

            var definition = (List<UserTypeDefinition>)((OkObjectResult)result).Value;

            Assert.NotNull(definition);
        }

        [Fact]
        public void GetUserTypesDisabled_ShouldBeSuccessful()
        {
            var result = functionToTest
                .GetUserTypesDisabled();

            Assert.NotNull(result);
            Assert.True(result.GetType() == typeof(OkObjectResult), "Assert is OkObjectResult type.");

            var definition = (List<UserTypeDefinition>)((OkObjectResult)result).Value;

            Assert.NotNull(definition);
        }

        [Theory]
        [InlineData(false, "name", ErrorCodes.InvalidUserTypeRequest)]
        [InlineData(true, null, ErrorCodes.InvalidUserTypeName)]
        [InlineData(true, "", ErrorCodes.InvalidUserTypeName)]
        [InlineData(true, " ", ErrorCodes.InvalidUserTypeName)]
        [InlineData(true, "admin", ErrorCodes.UserTypeNameAlreadyExists)]
        public async void CreateUserType_ShouldBeBadRequest(bool hasDefinition, string name, ErrorCodes error)
        {
            var result = await functionToTest
                .AddUserType(hasDefinition ? CreateUserTypeDefinition(new List<Action<UserTypeDefinition>>
                {
                    obj => obj.Name = name,
                }) : null)
                .ConfigureAwait(false);

            Assert.True(result.GetType() == typeof(BadRequestObjectResult), "Assert result is BadRequestObjectResult type.");

            var response = (ErrorDefinition)((BadRequestObjectResult)result).Value;

            Assertions.ErrorDefinitionIsNotNullOrEmpty(response);

            Assert.True(
                error.ToString().Equals(response.Code, StringComparison.InvariantCultureIgnoreCase),
                $"Assert ErrorDefinition.Code is {error}.");
        }

        [Fact]
        public async void CreateUserType_ShouldBeSuccessful()
        {
            var result = await functionToTest
                .AddUserType(CreateUserTypeDefinition(new List<Action<UserTypeDefinition>>
                {
                    obj => obj.Id = null
                }))
                .ConfigureAwait(false);

            Assert.NotNull(result);
            Assert.True(result.GetType() == typeof(OkObjectResult), "Assert is OkObjectResult type.");

            var definition = (UserTypeDefinition)((OkObjectResult)result).Value;

            Assert.NotNull(definition);
        }

        [Theory]
        [InlineData(false, "name", TestDataFactory.ValidUserTypeId, ErrorCodes.InvalidUserTypeRequest)]
        [InlineData(true, null, TestDataFactory.ValidUserTypeId, ErrorCodes.InvalidUserTypeName)]
        [InlineData(true, "", TestDataFactory.ValidUserTypeId, ErrorCodes.InvalidUserTypeName)]
        [InlineData(true, " ", TestDataFactory.ValidUserTypeId, ErrorCodes.InvalidUserTypeName)]
        [InlineData(true, "name", null, ErrorCodes.InvalidUserTypeId)]
        [InlineData(true, "name", "", ErrorCodes.InvalidUserTypeId)]
        [InlineData(true, "name", " ", ErrorCodes.InvalidUserTypeId)]
        [InlineData(true, "name", "invalidId", ErrorCodes.UserTypeNotFound)]
        [InlineData(true, "user", TestDataFactory.ValidUserTypeId, ErrorCodes.UserTypeNameAlreadyExists)]
        public async void UpdateUserType_ShouldBeBadRequest(bool hasDefinition, string name, string id, ErrorCodes error)
        {
            var result = await functionToTest
                .UpdateUserType(id, hasDefinition ? CreateUserTypeDefinition(new List<Action<UserTypeDefinition>>
                {
                    obj => obj.Name = name
                }) : null)
                .ConfigureAwait(false);

            Assert.True(result.GetType() == typeof(BadRequestObjectResult), "Assert result is BadRequestObjectResult type.");

            var response = (ErrorDefinition)((BadRequestObjectResult)result).Value;

            Assertions.ErrorDefinitionIsNotNullOrEmpty(response);

            Assert.True(
                error.ToString().Equals(response.Code, StringComparison.InvariantCultureIgnoreCase),
                $"Assert ErrorDefinition.Code is {error}.");
        }

        [Fact]
        public async void UpdateUserType_ShouldBeSuccessful()
        {
            var result = await functionToTest
                .UpdateUserType(TestDataFactory.ValidUserTypeId, CreateUserTypeDefinition())
                .ConfigureAwait(false);

            Assert.NotNull(result);
            Assert.True(result.GetType() == typeof(OkObjectResult), "Assert is OkObjectResult type.");

            var definition = (UserTypeDefinition)((OkObjectResult)result).Value;

            Assert.NotNull(definition);
        }

        [Theory]
        [InlineData(null, ErrorCodes.InvalidUserTypeId)]
        [InlineData("", ErrorCodes.InvalidUserTypeId)]
        [InlineData(" ", ErrorCodes.InvalidUserTypeId)]
        [InlineData("INVALIDID", ErrorCodes.UserTypeNotFound)]
        public async void DeleteUserType_ShouldBeBadRequest(string id, ErrorCodes error)
        {
            var result = await functionToTest
                .DeleteUserType(id)
                .ConfigureAwait(false);

            Assert.True(result.GetType() == typeof(BadRequestObjectResult), "Assert result is BadRequestObjectResult type.");

            var response = (ErrorDefinition)((BadRequestObjectResult)result).Value;

            Assertions.ErrorDefinitionIsNotNullOrEmpty(response);

            Assert.True(
                error.ToString().Equals(response.Code, StringComparison.InvariantCultureIgnoreCase),
                $"Assert ErrorDefinition.Code is {error}.");
        }

        [Fact]
        public async void DeleteUserType_ShouldBeSuccessful()
        {
            var result = await functionToTest
                .DeleteUserType(TestDataFactory.ValidUserTypeId)
                .ConfigureAwait(false);

            Assert.NotNull(result);
            Assert.True(result.GetType() == typeof(OkObjectResult), "Assert is OkObjectResult type.");

            var definition = (UserTypeDefinition)((OkObjectResult)result).Value;

            Assert.NotNull(definition);
        }

        private static UserTypeDefinition CreateUserTypeDefinition(List<Action<UserTypeDefinition>> customizes = null)
        {
            var definition = new UserTypeDefinition
            {
                Id = TestDataFactory.ValidUserTypeId,
                Name = "cliente",
            };

            if (customizes != null)
            {
                foreach (var customize in customizes)
                {
                    customize?.Invoke(definition);
                }
            }

            return definition;
        }
    }
}

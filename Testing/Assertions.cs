namespace Testing
{
    using Xunit;
    using Test.Api.Definition;

    public class Assertions
    {
        public static void ErrorDefinitionIsNotNullOrEmpty(ErrorDefinition errorDefinition)
        {
            Assert.False(errorDefinition == null, "Assert ErrorDefinition is not null.");
            Assert.False(string.IsNullOrWhiteSpace(errorDefinition.Message), "Assert ErrorDefinition.Message is not null or empty.");
        }
    }
}

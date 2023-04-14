using HotChocolate.AzureFunctions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs;
using System.Threading.Tasks;

namespace TestAzure.Api.Functions
{
    public class GraphqlFunctions
    {
        [FunctionName("GraphQL")]
        public Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "graphql/{**slug}")] HttpRequest req,
            [GraphQL] IGraphQLRequestExecutor executor)
        {
            return executor.ExecuteAsync(req);
        }
    }
}

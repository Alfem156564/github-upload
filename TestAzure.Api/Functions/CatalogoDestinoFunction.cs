using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using TestAzure.Api.Helpers;
using TestAzure.Api.Definition;
using Data.Contracts;

namespace TestAzure.Api.Functions
{
    public class CatalogoDestinoFunction
    {
        private readonly ICatalogoDestinoAccessServices _catalogoAccessServices;

        public CatalogoDestinoFunction(
            ICatalogoDestinoAccessServices catalogoAccessServices)
        {
            _catalogoAccessServices = catalogoAccessServices;
        }

        [FunctionName("GetCatalogoDestinos")]
        public async Task<IActionResult> GetCatalogoDestinos(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "get",
                Route = ApiRoutes.CatalogoDestino)] HttpRequest request)
        {
            var catalogos = _catalogoAccessServices
                .GetCatalogoDestinos();

            return new OkObjectResult(catalogos
                .ToListDefinition());
        }

        [FunctionName("GetCatalogoDestinosDisabled")]
        public async Task<IActionResult> GetCatalogoDestinosDisabled(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "get",
                Route = ApiRoutes.CatalogoDestinoDisabled)] HttpRequest request)
        {
            var catalogos = _catalogoAccessServices
                .GetCatalogoDestinosDisabled();

            return new OkObjectResult(catalogos
                .ToListDefinition());
        }

        [FunctionName("GetCatalogoDestinoById")]
        public async Task<IActionResult> GetCatalogoDestinoById(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "get",
                Route = ApiRoutes.CatalogoDestinoId)] HttpRequest request,
            int id)
        {
            var catalogo = _catalogoAccessServices
                .GetCatalogoDestinoById(id);

            return new OkObjectResult(catalogo
                .ToDefinition());
        }

        [FunctionName("AddCatalogoDestino")]
        public async Task<IActionResult> AddCatalogoDestino(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "post",
                Route = ApiRoutes.CatalogoDestino)] HttpRequest request)
        {
            var catalogoDefinition = await request
            .GetRequestBodyAsync<CatalogoDestinoDefinition>()
            .ConfigureAwait(continueOnCapturedContext: false);

            var catalogo = await _catalogoAccessServices
                .CreateCatalogoDestinoAsync(catalogoDefinition.Descripcion, "system");

            return new OkObjectResult(catalogo);
        }

        [FunctionName("UpdateCatalogoDestino")]
        public async Task<IActionResult> UpdateCatalogoDestino(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "post",
                Route = ApiRoutes.CatalogoDestinoId)] HttpRequest request,
            int id)
        {
            var catalogoDefinition = await request
            .GetRequestBodyAsync<CatalogoDestinoDefinition>()
            .ConfigureAwait(continueOnCapturedContext: false);

            var catalogo = await _catalogoAccessServices
                .UpdateCatalogoDestinoAsync(id, catalogoDefinition.Descripcion);

            return new OkObjectResult(catalogo);
        }

        [FunctionName("DeleteCatalogoDestino")]
        public async Task<IActionResult> DeleteCatalogoDestino(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "delete",
                Route = ApiRoutes.CatalogoDestinoId)] HttpRequest request,
            int id)
        {
            var catalogo = await _catalogoAccessServices
                .DisabledCatalogoDestinoAsync(id, "system");

            return new OkObjectResult(catalogo);
        }
    }
}

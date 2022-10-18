using Common.Models.Conekta;
using Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Test.Api.Definition;
using Test.Api.Helpers;

namespace Test.Api.Controllers
{
    [Route("api/conekta")]
    [ApiController]
    public class ConektaController : ControllerBase
    {
        private readonly IConektaManager conektaManager;

        public ConektaController(
            IConektaManager conektaManager)
        {
            this.conektaManager = conektaManager;
        }

        [HttpPost("cliente")]
        public async Task<IActionResult> PostCliente(ConektaCreateClienteModel model)
        {
            var cliente = await conektaManager
                .PostCliente(model)
                .ConfigureAwait(false);

            return new OkObjectResult(cliente);
        }

        [HttpGet("cliente/{customerId}")]
        public async Task<IActionResult> GetCliente(string customerId)
        {
            var cliente = await conektaManager
                .GetCliente(customerId)
                .ConfigureAwait(false);

            return new OkObjectResult(cliente);
        }

        [HttpPost("token")]
        public async Task<IActionResult> PostToken(ConektaSearchTokenModel model)
        {
            var cliente = await conektaManager
                .PostToken(model)
                .ConfigureAwait(false);

            return new OkObjectResult(cliente);
        }
    }
}

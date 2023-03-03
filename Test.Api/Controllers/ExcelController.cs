using Core.Contracts;
using Core.Managers;
using Microsoft.AspNetCore.Mvc;

namespace Test.Api.Controllers
{
    [Route("api/excel")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly IExcelManager excelManager;

        public ExcelController(
            IExcelManager excelManager)
        {
            this.excelManager = excelManager;
        }

        [HttpPost]
        public async Task<IActionResult> Excel()
        {
            if (Request.Form.Files.Any())
            {
                List<Tuple<int, string>> listUrls = new List<Tuple<int, string>>();
                foreach (var file in Request.Form.Files)
                {
                    var filePath = Path.GetTempFileName();

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await file.CopyToAsync(stream);

                        var url = excelManager
                            .CompararExcels(stream, file.FileName, "C:\\");

                        if (!url.DidSucceed)
                        {
                            return new BadRequestObjectResult(url.ErrorMessage);
                        }

                        return new OkObjectResult(url.Value);

                    }
                }
                return new BadRequestObjectResult("No se recibieron Arcivos");
            }
            else
            {
                return new BadRequestObjectResult("No se recibieron Arcivos");
            }
        }
    }
}

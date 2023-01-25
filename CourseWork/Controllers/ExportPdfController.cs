using CourseWork.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportPdfController : ControllerBase
    {
        private readonly IExportPdfService _exportPdfService;

        public ExportPdfController(IExportPdfService exportPdfService)
        {
            _exportPdfService = exportPdfService;
        }

        [HttpGet]
        public IActionResult GetPdf()
        {
            _exportPdfService.CreatePdf();
            return Ok("PDF Document created.");
        }
    }
}

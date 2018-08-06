using AquariumCalculator.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AquariumCalculator.API.Controllers
{

  [Route("api/[controller]")]
  public class PDFController : Controller
  {
    private IPDFService _pdfService;

    public PDFController(IPDFService pdfService)
    {
      _pdfService = pdfService;
    }

    [HttpGet]
    public IActionResult Index()
    {
      _pdfService.GeneratePDFFromView("Invoice", new InvoiceModel());

      return Ok();
    }
  }
}
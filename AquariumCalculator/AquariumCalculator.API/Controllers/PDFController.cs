using AquariumCalculator.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AquariumCalculator.API.Controllers
{
  [Route("api/[controller]")]
  public class PDFController : Controller
  {
    private readonly IInvoiceService _invoceServce;

    public PDFController(IInvoiceService invoiceService)
    {
      _invoceServce = invoiceService;
    }

    [HttpGet]
    public IActionResult Index()
    {
      _invoceServce.ProcessInovice();

      return Ok();
    }
  }
}
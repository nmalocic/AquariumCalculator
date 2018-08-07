using AquariumCalculator.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;

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
      try
      {
        var array = _pdfService.GeneratePDFFromView("Invoice", new InvoiceModel());
        return File(array, "application/pdf");
      }catch(Exception e) {
        return BadRequest();
      }
    }
  }
}
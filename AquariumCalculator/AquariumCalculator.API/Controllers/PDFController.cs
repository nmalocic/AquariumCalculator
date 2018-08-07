using AquariumCalculator.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AquariumCalculator.API.Controllers
{

  [Route("api/[controller]")]
  public class PDFController : Controller
  {
    private IPDFService _pdfService;
    private readonly IEmailService _emailService;

    public PDFController(IPDFService pdfService, IEmailService emailService)
    {
      _pdfService = pdfService;
      _emailService = emailService;
    }

    [HttpGet]
    public IActionResult Index()
    {
      try
      {
        var array = _pdfService.GeneratePDFFromView("Invoice", new InvoiceModel());
        _emailService.SendEmail("bdjuragin@gmail.com", "test", "test", array);
        return File(array, "application/pdf");
      }catch(Exception e) {
        return BadRequest();
      }
    }
  }
}
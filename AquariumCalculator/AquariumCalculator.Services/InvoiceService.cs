using AquariumCalculator.Contracts;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AquariumCalculator.Services
{
  public class InvoiceService : IInvoiceService
  {
    private readonly IEmailService _emailService;
    private readonly IPDFService _pdfService;
    private string InvoiceViewName => "Invoice";
    private string InoviceFolder => "Invoices";

    public InvoiceService(IPDFService pdfService, IEmailService emailService)
    {
      _emailService = emailService;
      _pdfService = pdfService;
    }

    public void ProcessInovice()
    {
      var pdf = _pdfService.GeneratePDFFromView(InvoiceViewName, new InvoiceModel());
      SavePdfToFile(pdf, "Test Inovice.pdf");
      //_emailService.SendEmail("")
    }

    private void SavePdfToFile(byte[] pdf, string fileName)
    {
      string invoiceFolder = Path.Combine(Directory.GetCurrentDirectory(), InoviceFolder, DateTime.Now.ToString("dd-MM-yyyy"));
      if(!Directory.Exists(invoiceFolder))
      {
        Directory.CreateDirectory(invoiceFolder);
      }

      File.WriteAllBytesAsync(Path.Combine(invoiceFolder, fileName), pdf);
    }
  }
}

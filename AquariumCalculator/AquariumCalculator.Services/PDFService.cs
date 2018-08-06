using AquariumCalculator.Contracts;
using DinkToPdf;
using DinkToPdf.Contracts;
using System.IO;
using System.Threading.Tasks;

namespace AquariumCalculator.Services
{
  public class PDFService : IPDFService
  {
    private readonly ITemplateService _templateService;
    private readonly IConverter _converter;

    public PDFService(ITemplateService templateService, IConverter converter)
    {
      _templateService = templateService;
      _converter = converter;
    }

    public byte[] GeneratePDFFromView<TModel>(string templateName, TModel model)
    {
      var documentContent = _templateService.RenderTemplateAsync(templateName, model);

      var globalSettings = new GlobalSettings
      {
        ColorMode = ColorMode.Color,
        Orientation = Orientation.Portrait,
        PaperSize = PaperKind.A4,
        Margins = new MarginSettings { Top = 10 },
        DocumentTitle = "PDF Report",
        Out = @"D:\PDFCreator\Employee_Report.pdf"
      };

      var objectSettings = new ObjectSettings
      {
        PagesCount = true,
        HtmlContent = documentContent,
        WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", "assets", "styles.css") }
      };

      var pdf = new HtmlToPdfDocument()
      {
        GlobalSettings = globalSettings,
        Objects = { objectSettings }
      };

      return _converter.Convert(pdf);
    }
  }
}
using System.Threading.Tasks;

namespace AquariumCalculator.Contracts
{
  public interface IPDFService
  {
    byte[] GeneratePDFFromView<TModel>(string templateName, TModel model);
  }
}

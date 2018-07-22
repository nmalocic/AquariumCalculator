using AquariumCalculator.Models;

namespace AquariumCalculator.Contracts
{
  public interface IGlassCatalog
  {
    GlassPrice GetPrice(double tickness);
  }
}

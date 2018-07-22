using AquariumCalculator.Models;
using AquariumCalculator.Contracts;

namespace AquariumCalculator.Services
{
  public class AquariumCatalog : IAquariumCatalog
  {
    private IGlassTickness _glassTickness;
    private IGlassCatalog _catalog;

    public AquariumCatalog(IGlassTickness glassTickness, IGlassCatalog catalog)
    {
      _glassTickness = glassTickness;
      _catalog = catalog;
    }

    public AquariumOffer GetOfferFor(Aquarium aquarium)
    {
      var glassTickness = _glassTickness.GetGlassTicknes(aquarium);
      var glassPrice = _catalog.GetPrice(glassTickness).Price;
      return new AquariumOffer(aquarium, glassTickness, glassPrice);
    }
  }
}
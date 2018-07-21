using AquariumCalculator.API.Models;

namespace AquariumCalculator.API.Bussines
{
  public class AquariumCatalog
  {
    private GlassTicknessCalculator _glassTickness;
    private GlassCatalog _catalog;

    public AquariumCatalog(GlassTicknessCalculator glassTickness, GlassCatalog catalog)
    {
      _glassTickness = glassTickness;
      _catalog = catalog;
    }

    public AquariumOffer GetOfferFor(Aquarium aquarium)
    {
      var glassTickness = _glassTickness.GetGlassTicknes(aquarium.LengthHeightRatio, aquarium.HeightInMilimeters);
      var glassPrice = _catalog.GetPrice(glassTickness).Price;
      return new AquariumOffer(aquarium, glassTickness, glassPrice);
    }
  }
}
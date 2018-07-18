using System;

namespace AquariumCalculatorTests
{
  internal class AquariumCatalog
  {
    private GlassTicknessCalculator _glassTickness;
    private GlassCatalog _catalog;

    public AquariumCatalog(GlassTicknessCalculator glassTickness, GlassCatalog catalog)
    {
      _glassTickness = glassTickness;
      _catalog = catalog;
    }

    internal AquariumOffer GetOfferFor(Aquarium aquarium)
    {
      var glassTickness = _glassTickness.GetGlassTicknes(aquarium.LengthHeightRatio, aquarium.HeightInMilimeters);
      var glassPrice = _catalog.GetPrice(glassTickness).Price;
      return new AquariumOffer(aquarium, glassTickness, glassPrice);
      throw new NotImplementedException();
    }
  }
}
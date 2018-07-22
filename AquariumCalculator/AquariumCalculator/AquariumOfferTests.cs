using AquariumCalculator.Models;
using AquariumCalculator.Services;
using Xunit;

namespace AquariumCalculatorTests
{
  public class AquariumOfferTests
  {
    [Fact]
    public void GivenAquarium_GetOffer()
    {

      MainPanelGlassStrengthConstants glasConstants = new MainPanelGlassStrengthConstants();

      GlassTicknessCalculator glassTickness = new GlassTicknessCalculator(glasConstants);
      GlassCatalog glassCatalog = new GlassCatalog();

      AquariumCatalog catalog = new AquariumCatalog(glassTickness, glassCatalog);

      Aquarium aquarium = new Aquarium(50, 50, 50);
      AquariumOffer offer = catalog.GetOfferFor(aquarium);

      Assert.Equal(1.25, offer.GlassSizeInMeters);
      Assert.Equal(7, offer.GlassTickness);
      Assert.Equal(25, offer.GlassPrice);
      Assert.Equal(31.25, offer.TotalGlassPrice);
    }
  }
}

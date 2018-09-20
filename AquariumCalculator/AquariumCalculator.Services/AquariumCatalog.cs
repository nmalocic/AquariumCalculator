using AquariumCalculator.Models;
using AquariumCalculator.Contracts;
using AquariumCalculator.Services.Configurators;

namespace AquariumCalculator.Services
{
  public class AquariumCatalog : IAquariumCatalog
  {
    private readonly PumpConfiguratior _pumpConfigurator;
    private readonly IGlassTickness _glassTickness;
    private readonly IGlassCatalog _catalog;
    private readonly SkimmerConfigurator _skimmerConfigurator;
    private readonly LightConfigurator _ligthConfigurator;

    public AquariumCatalog(
                          IGlassTickness glassTickness, 
                          IGlassCatalog catalog,
                          SkimmerConfigurator skimmerConfigurator,
                          PumpConfiguratior pumpConfigurator,
                          LightConfigurator lightConfigurator)
    {
      _glassTickness = glassTickness;
      _catalog = catalog;
      _skimmerConfigurator = skimmerConfigurator;
      _pumpConfigurator = pumpConfigurator;
      _ligthConfigurator = lightConfigurator;
    }

    public AquariumOffer GetOfferFor(Aquarium aquarium)
    {
      var glassTickness = _glassTickness.GetGlassTicknes(aquarium);
      var glassPrice = _catalog.GetPrice(glassTickness).Price;
      var skimmers = _skimmerConfigurator.GetSkimmerFor(aquarium);
      var pumps = _pumpConfigurator.GetPumpsFor(aquarium);
      var lights = _ligthConfigurator.GetLightsFor(aquarium);
      return new AquariumOffer(aquarium, glassTickness, glassPrice, skimmers, pumps, lights);
    }
  }
}
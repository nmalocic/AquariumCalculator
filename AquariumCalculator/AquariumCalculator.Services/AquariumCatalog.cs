using AquariumCalculator.Models;
using AquariumCalculator.Contracts;
using AquariumCalculator.Services.Repositories;
using AquariumCalculator.Contracts.Repository;

namespace AquariumCalculator.Services
{
  public class AquariumCatalog : IAquariumCatalog
  {
    private readonly IPumpRepository _pumpRepository;
    private readonly IGlassTickness _glassTickness;
    private readonly IGlassCatalog _catalog;
    private readonly ISkimmerRepository _skimmerRepository;

    public AquariumCatalog(IGlassTickness glassTickness, IGlassCatalog catalog, ISkimmerRepository skimerRepository, IPumpRepository pumpRepository)
    {
      _glassTickness = glassTickness;
      _catalog = catalog;
      _skimmerRepository = skimerRepository;
      _pumpRepository = pumpRepository;
    }

    public AquariumOffer GetOfferFor(Aquarium aquarium)
    {
      var glassTickness = _glassTickness.GetGlassTicknes(aquarium);
      var glassPrice = _catalog.GetPrice(glassTickness).Price;
      var skimmers = _skimmerRepository.GetSkimmersFor(aquarium);
      var pumps = _pumpRepository.GetAllPumps();
      return new AquariumOffer(aquarium, glassTickness, glassPrice, skimmers, pumps);
    }
  }
}
using AquariumCalculator.Models;

namespace AquariumCalculator.Contracts
{
  public interface IAquariumCatalog
  {
    AquariumOffer GetOfferFor(Aquarium aquarium);
  }
}

using AquariumCalculator.Contracts.Repository;
using AquariumCalculator.Models;
using System.Collections.Generic;
using System.Linq;

namespace AquariumCalculator.Services.Configurators
{
  public class SkimmerConfigurator
  {
    private ISkimmerRepository _skimmerRepository;

    public SkimmerConfigurator(ISkimmerRepository skimmerRepository)
    {
      _skimmerRepository = skimmerRepository;
    }

    public IEnumerable<Skimmer> GetSkimmerFor(Aquarium aquarium)
    {
      return _skimmerRepository
                        .GetAll()
                        .Where(skimmer => skimmer.MinVolume <= aquarium.Volume
                                  && skimmer.MaxVolume >= aquarium.Volume)
                        .OrderBy(skimmer => skimmer.Price)
                        .ThenBy(skimmer => skimmer.Name)
                        .Take(4);
      }
  }
}
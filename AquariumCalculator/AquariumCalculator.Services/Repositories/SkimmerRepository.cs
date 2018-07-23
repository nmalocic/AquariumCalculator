using AquariumCalculator.Models;
using System.Collections.Generic;
using System.Linq;

namespace AquariumCalculator.Services.Repositories
{
  public class SkimmerRepository
  {
    private List<Skimmer> _availableSkimmers = new List<Skimmer>();

    public IEnumerable<Skimmer> GetSkimmersFor(Aquarium aquarium)
    {
      return _availableSkimmers
                .Where(skimmer => skimmer.MinVolume <= aquarium.Volume
                    && skimmer.MaxVolume >= aquarium.Volume)
                .OrderBy(skimmer => skimmer.Price)
                .ThenBy(skimmer => skimmer.Name);
    }
  }
}

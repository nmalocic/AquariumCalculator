using AquariumCalculator.Contracts.Repository;
using AquariumCalculator.Models;
using System.Collections.Generic;
using System.Linq;

namespace AquariumCalculator.Services.Repositories
{
  public class SkimmerRepository : ISkimmerRepository
  {
    private List<Skimmer> _availableSkimmers = new List<Skimmer>();

    public SkimmerRepository()
    {
      _availableSkimmers.Add(new Skimmer(1, "Somatic S60", 25000, 130, 250));
      _availableSkimmers.Add(new Skimmer(2, "Somatic S90", 35000, 220, 500));
      _availableSkimmers.Add(new Skimmer(3, "Somatic S120", 45000, 450, 600));
      _availableSkimmers.Add(new Skimmer(4, "Somatic S60", 45000, 350, 700));
      _availableSkimmers.Add(new Skimmer(5, "Somatic S60", 60000, 460, 1200));
      _availableSkimmers.Add(new Skimmer(6, "Somatic S60", 75000, 700, 1200));
      _availableSkimmers.Add(new Skimmer(7, "Somatic S60", 95000, 800, 1600));
      _availableSkimmers.Add(new Skimmer(8, "Somatic S60", 130000, 1100, 2500));
    }

    public IEnumerable<Skimmer> GetSkimmersFor(Aquarium aquarium)
    {
      return _availableSkimmers
                .Where(skimmer => skimmer.MinVolume <= aquarium.Volume
                    && skimmer.MaxVolume >= aquarium.Volume)
                .OrderBy(skimmer => skimmer.Price)
                .ThenBy(skimmer => skimmer.Name)
                .Take(4);
    }
  }
}

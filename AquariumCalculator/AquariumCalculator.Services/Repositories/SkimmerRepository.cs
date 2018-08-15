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
      _availableSkimmers.Add(new Skimmer() { Id = 1, Name = "Somatic S60", MinVolume = 130, MaxVolume = 250, Price = 25000 });
      _availableSkimmers.Add(new Skimmer() { Id = 1, Name = "Somatic S90", MinVolume = 220, MaxVolume = 500, Price = 35000 });
      _availableSkimmers.Add(new Skimmer() { Id = 1, Name = "Somatic S120", MinVolume = 450, MaxVolume = 600, Price = 45000 });
      _availableSkimmers.Add(new Skimmer() { Id = 1, Name = "Somatic S60", MinVolume = 350, MaxVolume = 700, Price = 50000 });
      _availableSkimmers.Add(new Skimmer() { Id = 1, Name = "Somatic S60", MinVolume = 460, MaxVolume = 1200, Price = 60000 });
      _availableSkimmers.Add(new Skimmer() { Id = 1, Name = "Somatic S60", MinVolume = 700, MaxVolume = 1200, Price = 75000 });
      _availableSkimmers.Add(new Skimmer() { Id = 1, Name = "Somatic S60", MinVolume = 800, MaxVolume = 1600, Price = 95000 });
      _availableSkimmers.Add(new Skimmer() { Id = 1, Name = "Somatic S60", MinVolume = 1100, MaxVolume = 2500, Price = 130000 });
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

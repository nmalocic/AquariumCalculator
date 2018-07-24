using AquariumCalculator.Contracts.Repository;
using AquariumCalculator.Models;
using System.Collections.Generic;
using System.Linq;

namespace AquariumCalculator.Services.Repositories
{
  public class PumpRepository : IPumpRepository
  {
    public int flowOffset = 1000;
    private static List<Pump> _availablePumps = new List<Pump>();

    public PumpRepository()
    {
      _availablePumps.Add(new Pump() { Id = 1, Name = "Tunze 6015", MinFlow = 1800, MaxFlow = 1800, Price = 4290 });
      _availablePumps.Add(new Pump() { Id = 1, Name = "Tunze 6020", MinFlow = 1800, MaxFlow = 1800, Price = 4290 });
      _availablePumps.Add(new Pump() { Id = 1, Name = "Tunze 6025", MinFlow = 2500, MaxFlow = 2500, Price = 5990 });
      _availablePumps.Add(new Pump() { Id = 1, Name = "Jebao OW10", MinFlow = 300, MaxFlow = 4000, Price = 8400 });
      _availablePumps.Add(new Pump() { Id = 1, Name = "Jebao OW25", MinFlow = 800, MaxFlow = 8000, Price = 10900 });
      _availablePumps.Add(new Pump() { Id = 1, Name = "Jebao OW40", MinFlow = 2000, MaxFlow = 15000, Price = 14500 });
      _availablePumps.Add(new Pump() { Id = 1, Name = "Jebao OW60", MinFlow = 5000, MaxFlow = 20000, Price = 18000 });
    }

    public IEnumerable<Pump> GetPumpsFor(Aquarium aquarium) 
    {
      return _availablePumps
                .Where(pump => pump.MinFlow <= aquarium.Volume && pump.MaxFlow >= aquarium.Volume + flowOffset)
                .OrderBy(pump => pump.Price)
                .ThenBy(pump => pump.Name);
    }
  }
}

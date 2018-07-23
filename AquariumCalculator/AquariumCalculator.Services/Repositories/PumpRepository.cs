using AquariumCalculator.Models;
using System.Collections.Generic;
using System.Linq;

namespace AquariumCalculator.Services.Repositories
{
  public class PumpRepository
  {
    public int flowOffset = 1000;
    private static List<Pump> _availablePumps = new List<Pump>();

    public IEnumerable<Pump> GetPumpsFor(Aquarium aquarium) 
    {
      return _availablePumps
                .Where(pump => pump.MinFlow <= aquarium.Volume && pump.MaxFlow >= aquarium.Volume + flowOffset)
                .OrderBy(pump => pump.Price)
                .ThenBy(pump => pump.Name);
    }
  }
}

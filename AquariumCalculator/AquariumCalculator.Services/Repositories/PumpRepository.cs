using AquariumCalculator.Contracts.Repository;
using AquariumCalculator.Models;
using System.Collections.Generic;

namespace AquariumCalculator.Services.Repositories
{
  public class PumpRepository : IPumpRepository
  {
    public int flowOffset = 1000;
    private List<Pump> _availablePumps = new List<Pump>();

    public PumpRepository()
    {
      _availablePumps.Add(new Pump(1, 1, "Tunze 6015", 1800, 1800, 4290));
      _availablePumps.Add(new Pump(2, 1, "Tunze 6020", 1800, 1800, 4290 ));
      _availablePumps.Add(new Pump(3, 1, "Tunze 6025", 2500, 2500, 5990 ));
      _availablePumps.Add(new Pump(4, 2, "Jebao OW10", 300, 4000, 8400 ));
      _availablePumps.Add(new Pump(5, 2, "Jebao OW25", 800, 8000, 10900 ));
      _availablePumps.Add(new Pump(6, 2, "Jebao OW40", 2000, 15000, 14500 ));
      _availablePumps.Add(new Pump(7, 2, "Jebao OW60", 5000, 20000, 18000 ));
    }

    public IEnumerable<Pump> GetAllPumps() 
    {
      return _availablePumps;
    }
  }
}

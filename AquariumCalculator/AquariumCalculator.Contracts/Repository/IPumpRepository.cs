using AquariumCalculator.Models;
using System.Collections.Generic;

namespace AquariumCalculator.Contracts.Repository
{
  public interface IPumpRepository
  {
    IEnumerable<Pump> GetPumpsFor(Aquarium aquarium);
  }
}

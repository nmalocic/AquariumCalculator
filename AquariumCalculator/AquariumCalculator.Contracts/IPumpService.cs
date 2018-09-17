using AquariumCalculator.Models;
using System.Collections.Generic;

namespace AquariumCalculator.Contracts
{
  public interface IPumpService
  {
    IEnumerable<PumpOffer> FilterPumps(Aquarium aquarium);
  }
}

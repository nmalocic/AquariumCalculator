using AquariumCalculator.Models;
using System.Collections.Generic;

namespace AquariumCalculator.Services.PumpStrategy
{
  public class PumpOffer
  {
    private List<Pump> Pumps { get; set; } = new List<Pump>(2);

    public PumpOffer(Pump single)
    {
      Pumps.Add(single);
    }

    public PumpOffer(Pump first, Pump second)
    {
      Pumps.Add(first);
      Pumps.Add(second);
    }

    public IEnumerable<Pump> Offer => Pumps;
  }
}
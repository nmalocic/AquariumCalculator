using System.Collections.Generic;
using System.Linq;

namespace AquariumCalculator.Models
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

    public string Id => Offer
                          .OrderBy(x => x.Id)
                          .Select( x => x.Id.ToString())
                          .Aggregate((current, next) => current + next);
  }
}
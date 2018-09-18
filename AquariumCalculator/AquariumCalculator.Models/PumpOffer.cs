using System.Collections.Generic;
using System.Linq;

namespace AquariumCalculator.Models
{
  public class PumpOffer
  {
    private List<Models.Pump> Pumps { get; set; } = new List<Models.Pump>(2);

    public PumpOffer(Models.Pump single)
    {
      Pumps.Add(single);
    }

    public PumpOffer(Models.Pump first, Models.Pump second)
    {
      Pumps.Add(first);
      Pumps.Add(second);
    }

    public IEnumerable<Models.Pump> Offer => Pumps;
    public string Id => Offer
                            .OrderBy(x => x.Id)
                            .Select( x => x.Id.ToString())
                            .Aggregate((current, next) => current + next);
  }
}
using System.Collections.Generic;
using System.Linq;

namespace AquariumCalculator.Models
{
  public class PumpOfferComparer : IEqualityComparer<PumpOffer>
  {
    public bool Equals(PumpOffer x, PumpOffer y)
    {
      return x.Id.Equals(y.Id);
    }

    public int GetHashCode(PumpOffer obj)
    {
      unchecked
      {
        int hash = 17;
        hash = hash * 23 + obj.Id.GetHashCode();

        return hash;
      }
    }
  }

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
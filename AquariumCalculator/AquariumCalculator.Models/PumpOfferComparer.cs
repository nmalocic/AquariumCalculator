using System.Collections.Generic;

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
}
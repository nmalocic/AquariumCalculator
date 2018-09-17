using AquariumCalculator.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AquariumCalculatorTests
{
  public class PumpTests
  {
    [Fact]
    public void PumpOfferComaprerTest()
    {
      Pump first = new Pump(1, 1, "test", 1, 1, 1);
      Pump second = new Pump(2, 1, "test", 1, 1, 1);

      PumpOffer offerOne = new PumpOffer(first, second);
      PumpOffer offerTwo = new PumpOffer(second, first);

      List<PumpOffer> offers = new List<PumpOffer>();
      offers.Add(offerOne);
      offers.Add(offerTwo);
      Assert.Equal(2, offers.Count);
      
      var defaultComparer = offers.Distinct();
      Assert.Equal(2, offers.Count);
      
      var filtered = offers.Distinct(new PumpOfferComparer());
      Assert.Equal(1, filtered.Count());
    }
  }
}

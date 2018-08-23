using AquariumCalculator.Contracts.Repository;
using AquariumCalculator.Models;
using System.Collections.Generic;
using System.Linq;

namespace AquariumCalculator.Services.PumpStrategy
{

  public class PumpService
  {
    private readonly double maxFlow;
    private readonly double minFlow;
    private readonly IPumpRepository _pumpRepository;
    private double SPSConstant = 30;
    private double SPSPrecent = 10;

    public PumpService(double volume, IPumpRepository pumpRepository) 
    {
      _pumpRepository = pumpRepository;
      double flow = volume * SPSConstant;
      maxFlow = flow + (flow * SPSPrecent / 100);
      minFlow = flow - (flow * SPSPrecent / 100);
    }

    public IEnumerable<Pump> FilterPumps(IEnumerable<Pump> pumps) 
    {
      return Enumerable.Empty<Pump>();
    }

    private IEnumerable<PumpOffer> GetOfferUsingSamePumps()
    {
      return _pumpRepository
                .GetAllPumps()
                .Where(CanUseSamePumpTwice)
                .Select(x => new PumpOffer(x, x));
                
    }

    private IEnumerable<PumpOffer> GetOfferUsingDifferentPumps()
    {
      List<Pump> pumps = _pumpRepository.GetAllPumps().ToList();

      return pumps
        .SelectMany(first => pumps.Where(second => CanCombinePumps(first, second))
                                  .Select(second => new PumpOffer(first, second)));

    }

    private IEnumerable<PumpOffer> UseOnlyOnePump()
    {
      return _pumpRepository.GetAllPumps()
                            .Where(CanUsePump)
                            .Select(x => new PumpOffer(x));
    }

    private bool CanUseSamePumpTwice(Pump pump)
    {
      return CanUsePumpModifier(pump, 2);
    }

    private bool CanUsePump(Pump pump)
    {
      return CanUsePumpModifier(pump, 1);
    }

    private bool CanUsePumpModifier(Pump pump, double modifier)
    {
      return pump.MinUsage / modifier < maxFlow && 
             pump.MaxUsage / modifier > minFlow;
    }

    private bool CanCombinePumps(Pump first, Pump second)
    {
      return first.ManifacturerId.Equals(second.ManifacturerId) &&
             first.MinUsage + second.MinUsage < maxFlow && 
             first.MaxUsage + second.MaxUsage > minFlow;
    }
  }
}
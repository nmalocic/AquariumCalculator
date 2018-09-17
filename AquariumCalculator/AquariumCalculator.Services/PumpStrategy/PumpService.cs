using AquariumCalculator.Contracts;
using AquariumCalculator.Contracts.Repository;
using AquariumCalculator.Models;
using System.Collections.Generic;
using System.Linq;

namespace AquariumCalculator.Services.PumpStrategy
{
  public class PumpService : IPumpService
  {
    private readonly IPumpRepository _pumpRepository;
    private double SPSConstant = 30;
    private double SPSPrecent = 10;
    private int maxNumberInOffer = 4;

    public PumpService(IPumpRepository pumpRepository) 
    {
      _pumpRepository = pumpRepository;

    }

    public IEnumerable<PumpOffer> FilterPumps(Aquarium aquarium) 
    {
      double flow = aquarium.Volume * SPSConstant;
      var maxFlow = flow + (flow * SPSPrecent / 100);
      var minFlow = flow - (flow * SPSPrecent / 100);
      var pumps = _pumpRepository.GetAllPumps();

      var twoPumpsSameModel = GetOfferUsingSamePumps(pumps, maxFlow, minFlow);
      var twoPumpsDifferentModel = GetOfferUsingDifferentPumps(pumps, maxFlow, minFlow);
      var onePump = GetOfferUsingOnePump(pumps, maxFlow, minFlow);

      return twoPumpsSameModel
             .Concat(twoPumpsDifferentModel)
             .Concat(onePump)
             .Take(maxNumberInOffer);
    }

    private IEnumerable<PumpOffer> GetOfferUsingSamePumps(IEnumerable<Models.Pump> pumps, double maxFlow, double minFlow)
    {
      return pumps
                .Where(x => CanUseSamePumpTwice(x, maxFlow, minFlow))
                .Select(x => new PumpOffer(x, x))
                .Take(maxNumberInOffer);
    }

    private IEnumerable<PumpOffer> GetOfferUsingDifferentPumps(IEnumerable<Models.Pump> pumps, double maxFlow, double minFlow)
    {
      return pumps.SelectMany(first => pumps.Where(second => CanCombinePumps(first, second, maxFlow, minFlow))
                                            .Select(second => new PumpOffer(first, second)))
                    .Take(maxNumberInOffer);

    }

    private IEnumerable<PumpOffer> GetOfferUsingOnePump(IEnumerable<Models.Pump> pumps, double maxFlow, double minFlow)
    {
      return pumps.Where(x => CanUsePump(x, maxFlow, minFlow))
                  .Select(x => new PumpOffer(x))
                  .Take(maxNumberInOffer);
    }

    private bool CanUseSamePumpTwice(Models.Pump pump, double maxFlow, double minFlow)
    {
      return CanUsePumpModifier(pump, 2, maxFlow, minFlow);
    }

    private bool CanUsePump(Models.Pump pump, double maxFlow, double minFlow)
    {
      return CanUsePumpModifier(pump, 1, maxFlow, minFlow);
    }

    private bool CanUsePumpModifier(Models.Pump pump, double modifier, double maxFlow, double minFlow)
    {
      return pump.MinUsage / modifier < maxFlow && 
             pump.MaxUsage / modifier > minFlow;
    }

    private bool CanCombinePumps(Models.Pump first, Models.Pump second, double maxFlow, double minFlow)
    {
      return first.ManifacturerId.Equals(second.ManifacturerId) &&
             first.MinUsage + second.MinUsage < maxFlow && 
             first.MaxUsage + second.MaxUsage > minFlow;
    }
  }
}
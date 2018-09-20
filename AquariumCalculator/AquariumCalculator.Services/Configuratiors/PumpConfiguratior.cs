using AquariumCalculator.Contracts.Repository;
using AquariumCalculator.Models;
using System.Collections.Generic;
using System.Linq;

namespace AquariumCalculator.Services.Configurators
{
  public class PumpConfiguratior
  {
    private readonly IPumpRepository _pumpRepository;
    private double SPSConstant = 30;
    private double SPSPrecent = 10;
    private int maxNumberInOffer = 4;
    private PumpOfferComparer comparer = new PumpOfferComparer();

    public PumpConfiguratior(IPumpRepository pumpRepository) 
    {
      _pumpRepository = pumpRepository;

    }

    public IEnumerable<PumpOffer> GetPumpsFor(Aquarium aquarium) 
     {
      double flow = aquarium.Volume * SPSConstant;
      var maxFlow = flow + (flow * SPSPrecent / 100);
      var minFlow = flow - (flow * SPSPrecent / 100);
      var pumps = _pumpRepository.GetAllPumps();

      var twoPumpsSameModel = GetOfferUsingSamePumps(pumps, maxFlow, minFlow).ToList();
      var twoPumpsDifferentModel = GetOfferUsingDifferentPumps(pumps, maxFlow, minFlow).ToList();
      var onePump = GetOfferUsingOnePump(pumps, maxFlow, minFlow).ToList();

      return twoPumpsSameModel
             .Concat(twoPumpsDifferentModel)
             .Concat(onePump)
             .Take(maxNumberInOffer);
    }

    private IEnumerable<PumpOffer> GetOfferUsingSamePumps(IEnumerable<Pump> pumps, double maxFlow, double minFlow)
    {
      return pumps
                .Where(x => CanUseSamePumpTwice(x, maxFlow, minFlow))
                .Select(x => new PumpOffer(x, x))
                .Distinct(comparer)
                .Take(maxNumberInOffer);
    }

    private IEnumerable<PumpOffer> GetOfferUsingDifferentPumps(IEnumerable<Pump> pumps, double maxFlow, double minFlow)
    {
      return pumps.SelectMany(first => pumps.Where(second => CanCombinePumps(first, second, maxFlow, minFlow))
                                            .Select(second => new PumpOffer(first, second)))
                    .Distinct(comparer)
                    .Take(maxNumberInOffer);

    }

    private IEnumerable<PumpOffer> GetOfferUsingOnePump(IEnumerable<Pump> pumps, double maxFlow, double minFlow)
    {
      return pumps.Where(x => CanUsePump(x, maxFlow, minFlow))
                  .Select(x => new PumpOffer(x))
                  .Distinct(comparer)
                  .Take(maxNumberInOffer);
    }

    private bool CanUseSamePumpTwice(Pump pump, double maxFlow, double minFlow)
    {
      return CanUsePumpModifier(pump, 2, maxFlow, minFlow);
    }

    private bool CanUsePump(Pump pump, double maxFlow, double minFlow)
    {
      return CanUsePumpModifier(pump, 1, maxFlow, minFlow);
    }

    private bool CanUsePumpModifier(Pump pump, double modifier, double maxFlow, double minFlow)
    {
      return pump.MinUsage * modifier < maxFlow && 
             pump.MaxUsage * modifier > minFlow;
    }

    private bool CanCombinePumps(Pump first, Pump second, double maxFlow, double minFlow)
    {
      return !first.Id.Equals(second.Id) &&
             first.ManifacturerId.Equals(second.ManifacturerId) &&
             first.MinUsage + second.MinUsage < maxFlow && 
             first.MaxUsage + second.MaxUsage > minFlow;
    }
  }
}
using AquariumCalculator.Models;
using System.Collections.Generic;
using System.Linq;

namespace AquariumCalculator.Services.PumpStrategy
{
  public class SPSPumpStrategy
  {
    private readonly double maxFlow;
    private readonly double minFlow;
    private double SPSConstant = 30;
    private double SPSPrecent = 10;

    public SPSPumpStrategy(double volume) 
    {
      double flow = volume * SPSConstant;
      maxFlow = flow + (flow * SPSPrecent / 100);
      minFlow = flow - (flow * SPSPrecent / 100);
    }

    public IEnumerable<Pump> FilterPumps(IEnumerable<Pump> pumps) 
    {
      
      return Enumerable.Empty<Pump>();
    }
  }
}
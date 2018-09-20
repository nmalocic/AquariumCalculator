using System.Collections.Generic;

namespace AquariumCalculator.Models
{
  public class AquariumOffer
  {
    private readonly Aquarium aquarium;
    private double profitMargin = 2;

    public AquariumOffer(
                        Aquarium aquarium,
                        double glassTickness, 
                        double glassPrice, 
                        IEnumerable<Skimmer> skimmers, 
                        IEnumerable<PumpOffer> pumps,
                        IEnumerable<LightOffer> lights)
    {
      this.aquarium = aquarium;
      GlassTickness = glassTickness;
      GlassPrice = glassPrice;
      Skimmers = skimmers;
      Pumps = pumps;
      Lights = lights;
    }

    public double GlassTickness { get; }
    public double GlassPrice { get; }
    public double GlassSizeInMeters => aquarium.GlassSizeInMeters;
    public double TotalGlassPrice => GlassSizeInMeters * GlassPrice;
    public double VolumeInLeters => aquarium.Volume;
    public double SiliconPrice => aquarium.SiliconPrice;
    public double TotalPrice => TotalGlassPrice + SiliconPrice;
    public double TotalPriceWithProfit => TotalPrice * profitMargin;

    public double Sand => aquarium.BaseArea * 2 / 1000;
    public IEnumerable<Skimmer> Skimmers { get; }
    public IEnumerable<PumpOffer> Pumps { get; }
    public IEnumerable<LightOffer> Lights { get; }
  }
}
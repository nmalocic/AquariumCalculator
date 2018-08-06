using System.Collections.Generic;

namespace AquariumCalculator.Models
{
  public class AquariumOffer
  {
    private readonly Aquarium aquarium;
    private double profitMargin = 2;

    public AquariumOffer(Aquarium aquarium, double glassTickness, double glassprice, IEnumerable<Skimmer> skimmers, IEnumerable<Pump> pumps)
    {
      this.aquarium = aquarium;
      GlassTickness = glassTickness;
      GlassPrice = glassprice;
      Skimmers = skimmers;
      Pumps = pumps;
    }

    public double GlassTickness { get; }
    public double GlassPrice { get; }
    public double GlassSizeInMeters => aquarium.GlassSizeInMeters;
    public double TotalGlassPrice => GlassSizeInMeters * GlassPrice;
    public double VolumeInLeters => aquarium.Volume;
    public double SiliconPrice => aquarium.SiliconPrice;
    public double TotalPrice => TotalGlassPrice + SiliconPrice;
    public double TotalPriceWithProfit => TotalPrice * profitMargin;
    public IEnumerable<Skimmer> Skimmers { get; }
    public IEnumerable<Pump> Pumps { get; }
  }
}
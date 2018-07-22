namespace AquariumCalculator.Models
{
  public class AquariumOffer
  {
    private readonly Aquarium aquarium;
    private double profitMargin = 2;

    public AquariumOffer(Aquarium aquarium, double glassTickness, double glassprice)
    {
      this.aquarium = aquarium;
      GlassTickness = glassTickness;
      GlassPrice = glassprice;
    }

    public double GlassTickness { get; }
    public double GlassPrice { get; }
    public double GlassSizeInMeters => aquarium.GlassSizeInMeters;
    public double TotalGlassPrice => GlassSizeInMeters * GlassPrice;
    public double VolumeInLeters => aquarium.Volume;
    public double SiliconPrice => aquarium.SiliconPrice;
    public double TotalPrice => TotalGlassPrice + SiliconPrice;
    public double TotalPriceWithProfit => TotalPrice * profitMargin;
  }
}
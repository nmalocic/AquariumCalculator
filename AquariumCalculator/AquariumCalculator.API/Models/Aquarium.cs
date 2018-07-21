namespace AquariumCalculator.API.Models
{
  public class Aquarium
  {
    private double length;
    private double width;
    private readonly int _toLiters = 1000;

    public Aquarium(double length, double width, double height)
    {
      this.length = length;
      this.width = width;
      Height = height;
    }

    public double GlassSizeInMeters => GlassSizeInCentimeter / 10000;
    public double Height { get; }
    public double HeightInMilimeters => Height * 10;
    public double Volume => length * width * Height / _toLiters;
    public double LengthHeightRatio => length / Height;
    public double GlassSizeInCentimeter => 2 * WidthArea + 2 * LengthArea + BaseArea;
    public double SiliconPrice => Volume / 50 * 10;

    
    private double WidthArea => width * Height;
    private double LengthArea => length * Height;
    private double BaseArea => width * length;
  }
}
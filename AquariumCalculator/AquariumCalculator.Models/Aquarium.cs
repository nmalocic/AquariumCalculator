namespace AquariumCalculator.Models
{
  public class Aquarium
  {
    private double Length { get; set; }
    private double Width { get; set; }
    private readonly int _toLiters = 1000;

    public Aquarium(double length, double width, double height)
      : this(length, width, height, 3.8) { }

    public Aquarium(double length, double width, double height, double safeFactor)
    {
      Length = length;
      Width = width;
      Height = height;
      SafeFactor = safeFactor;
    }

    public double SafeFactor { get; } = 3.8;

    public double GlassSizeInMeters => GlassSizeInCentimeter / 10000;
    public double Height { get; set; }
    public double HeightInMilimeters => Height * 10;
    public double Volume => Length * Width * Height / _toLiters;
    public double LengthHeightRatio => Length / Height;
    public double GlassSizeInCentimeter => 2 * WidthArea + 2 * LengthArea + BaseArea;
    public double SiliconPrice => Volume / 50 * 10;

    
    private double WidthArea => Width * Height;
    private double LengthArea => Length * Height;
    private double BaseArea => Width * Length;
  }
}
namespace AquariumCalculator.API.Models
{
  public class GlassPrice
  {
    public GlassPrice(double tickness, double price)
    {
      Tickness = tickness;
      Price = price;
    }

    public double Tickness { get; }
    public double Price { get; }
  }
}

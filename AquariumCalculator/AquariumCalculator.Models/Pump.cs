namespace AquariumCalculator.Models
{
  public class Pump
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int MinFlow { get; set; }
    public int MaxFlow { get; set; }
  }
}

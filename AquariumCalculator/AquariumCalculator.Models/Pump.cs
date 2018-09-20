namespace AquariumCalculator.Models
{
  public class Pump
  {
    public Pump(int id, int manifacturerId, string name, int minFlow, int maxFlow, double price)
    {
      Id = id;
      Name = name;
      ManifacturerId = manifacturerId;
      Price = price;
      MinFlow = minFlow;
      MaxFlow = maxFlow;
    }

    public int Id { get; }
    public int ManifacturerId { get; }
    public string Name { get; }
    public double Price { get;}
    public int MinFlow { get; }
    public int MaxFlow { get; }

    public double MaxUsage => MaxFlow;
    public double MinUsage => MaxFlow == MinFlow ? MinFlow : MaxFlow * 0.6;
  }
}

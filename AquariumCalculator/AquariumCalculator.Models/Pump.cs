namespace AquariumCalculator.Models
{
  public class Pump
  {
    public Pump(int id, int manifacturerId, string name, double price, int minFlow, int maxFlow)
    {
      Id = id;
      Name = name;
      Price = price;
      MinFlow = MinFlow;
      MaxFlow = MaxFlow;
    }

    public int Id { get; set; }
    public int ManifacturerId { get; }
    public string Name { get; }
    public double Price { get;}
    public int MinFlow { get; }
    public int MaxFlow { get; }

    public double MaxUsage => MaxFlow;
    public double MinUsage => MaxFlow == MinFlow ? MinFlow : MaxFlow * 0.6;
  }
}

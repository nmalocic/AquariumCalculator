namespace AquariumCalculator.Models
{
  public class Skimmer
  {
    public Skimmer(int id, string name, double price, int minVolume, int maxVolume)
    {
      Id = id;
      Name = name;
      Price = price;
      MinVolume = minVolume;
      MaxVolume = maxVolume;
    }

    public int Id { get; }
    public string Name { get; }
    public double Price { get; }
    public int MinVolume { get; }
    public int MaxVolume { get; }
  }
}
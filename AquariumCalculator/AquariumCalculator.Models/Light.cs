namespace AquariumCalculator.Models
{
  public class Light
  {
    public Light(int id, string name, double price, int length, int width, int height) 
    {
      Id = id;
      Name = name;
      Price = price;
      Length = length;
      Width = width;
      Height = height;
    }

    public int Id { get; }
    public string Name { get; }
    public double Price { get; }
    public int Length { get; }
    public int Width { get; }
    public int Height { get; }
  }
}
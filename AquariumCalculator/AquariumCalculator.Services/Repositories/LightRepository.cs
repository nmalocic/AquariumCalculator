using AquariumCalculator.Contracts.Repository;
using AquariumCalculator.Models;
using System.Collections.Generic;

namespace AquariumCalculator.Services.Repositories
{
  public class LightRepository : ILightRepository
  {
    private List<Light> lights = new List<Light>();

    public LightRepository()
    {
      lights.Add(new Light(1, "X30", 21600, 70, 50, 50));
      lights.Add(new Light(2, "X60", 36000, 120, 50, 50));
      lights.Add(new Light(3, "Aquareef Pro nano", 36000, 60, 60, 100));
      lights.Add(new Light(4, "Aquareef Pro3", 60000, 90, 60, 100));
      lights.Add(new Light(4, "Aquareef Pro3+", 84000, 130, 60, 100));
      lights.Add(new Light(4, "ATI Hybrid ", 240000, 200, 80, 80));
    }

    public IEnumerable<Light> GetAll() 
    {
      return lights;
    }
  }
}
using AquariumCalculator.Models;
using System.Collections.Generic;

namespace AquariumCalculator.Contracts.Repository
{
  public interface ILightRepository
  {
    IEnumerable<Light> GetAll();
  }
}
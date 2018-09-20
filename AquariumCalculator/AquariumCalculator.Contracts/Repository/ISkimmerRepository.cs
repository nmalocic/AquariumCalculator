using AquariumCalculator.Models;
using System.Collections.Generic;

namespace AquariumCalculator.Contracts.Repository
{
  public interface ISkimmerRepository
  {
    IEnumerable<Skimmer> GetAll();
  }
}

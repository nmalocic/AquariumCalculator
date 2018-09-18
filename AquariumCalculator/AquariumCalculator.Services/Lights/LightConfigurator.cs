
using AquariumCalculator.Models;
using AquariumCalculator.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AquariumCalculator.Services.Lights
{
  internal sealed class LightConfigurator
  {
    private const int lengthCoverageOffset = 10;
    private const int widthCoverageOffset = 5;
    private readonly LightRepository _repository;

    public LightConfigurator(LightRepository repository)
    {
      _repository = repository;
    }

    public IEnumerable<LightOffer> GetLightsForAquarium(Aquarium aquarium)
    {
      var viableLights = _repository.GetAll().Where(x => x.Height >= aquarium.Height);

      foreach(Light currentLight in viableLights)
      {
        int lengthCovered = currentLight.Length - lengthCoverageOffset;
        int widthCovered = currentLight.Width - widthCoverageOffset;

        int numberOfLigthsNeededToCoverAquarium = CaluculateNumberOfLights(aquarium, lengthCovered, widthCovered);
        yield return new LightOffer(numberOfLigthsNeededToCoverAquarium, currentLight);
      }
    }

    private int CaluculateNumberOfLights(Aquarium aquarium, int lengthCovered, int widthCovered)
    {
      int numberToCoverLength = CalculateNumberForLength(aquarium, lengthCovered);
      int numberToCoverWidth = CalculateNumberForWidth(aquarium, widthCovered);

      return numberToCoverLength * numberToCoverWidth;
    }

    private int CalculateNumberForLength(Aquarium aquarium, int lengthCovered)
    {

      return (int)Math.Ceiling(aquarium.Length / lengthCovered);
    }

    private int CalculateNumberForWidth(Aquarium aquarium, int widthCovered)
    {
      return (int)Math.Ceiling(aquarium.Width / widthCovered);
    }
  }
}

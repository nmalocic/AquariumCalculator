using AquariumCalculator.Contracts;
using AquariumCalculator.Models;
using System;

namespace AquariumCalculator.Services
{
  public class GlassTicknessCalculator : IGlassTickness
  {
    private IGlassStrength _glassStrengthConstants;
    private readonly double tensileStrengthOfGlass = 19.2;
    private readonly double constant = 0.00001;

    public GlassTicknessCalculator(IGlassStrength glassStrengthConstants)
    {
      _glassStrengthConstants = glassStrengthConstants;
    }

    public double GetGlassTicknes(Aquarium aquarium)
    {
      var height = aquarium.HeightInMilimeters;
      var bendingStress = tensileStrengthOfGlass / aquarium.SafeFactor;
      var betaConstant = _glassStrengthConstants.GetStrength(aquarium.LengthHeightRatio).Beta;

      var tickness = Math.Sqrt(betaConstant * height * height * height * constant / bendingStress);

      return Math.Ceiling(tickness);
    }
  }
}
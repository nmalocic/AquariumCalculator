using System;

namespace AquariumCalculator.API.Bussines
{
  public class GlassTicknessCalculator
  {
    private IGlassStrength _glassStrengthConstants;
    private double _safeFactor;
    private double TensileStrenghOfglass = 19.2;
    private double constant = 0.00001;

    private double BendingStress => TensileStrenghOfglass / _safeFactor;

    public GlassTicknessCalculator(IGlassStrength glassStrengthConstants)
    {
      _glassStrengthConstants = glassStrengthConstants;
      //TODO: Move to configuration
      _safeFactor = 3.8;
    }

    public double GetGlassTicknes(double lengthWidthRatio, double height)
    {
      var betaConstant = _glassStrengthConstants.GetStrength(lengthWidthRatio).Beta;

      var tickness = Math.Sqrt(betaConstant * height * height * height * constant / BendingStress);

      return Math.Ceiling(tickness);
    }
  }
}
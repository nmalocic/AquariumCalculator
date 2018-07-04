using System;

namespace AquariumCalculatorTests
{
    internal class GlassTicknessCalculator
    {

        private readonly double constant = 0.00001;

        // private static readonly double _safeFactor = 3.8;
        // private static readonly double TensileStrenghOfglass = 19.2;
        // BendingStress = TensileStrenghOfglass / _safeFactor;
        private readonly double BendingStress = 5.05263157895;

        private IGlassStrength _glassStrengthConstants;

        public GlassTicknessCalculator(IGlassStrength glassStrengthConstants)
        {
            _glassStrengthConstants = glassStrengthConstants;
        }

        internal double GetglassTicknes(double lengthWidthRatio, double height)
        {
            var betaConstant = _glassStrengthConstants.GetStrength(lengthWidthRatio).Beta;

            var tickness = Math.Sqrt(betaConstant * height * height * height * constant / BendingStress);

            return Math.Ceiling(tickness);
        }
    }
}
using System;

namespace AquariumCalculatorTests
{
    internal class GlassTicknessCalculator
    {
        private MainPanelGlassStrengthConstants _glassStrengthConstants;
        private double _safeFactor;
        private double TensileStrenghOfglass = 19.2;
        private double constant = 0.00001;

        private double BendingStress => TensileStrenghOfglass / _safeFactor;

        public GlassTicknessCalculator(MainPanelGlassStrengthConstants glassStrengthConstants)
        {
            _glassStrengthConstants = glassStrengthConstants;
            //TODO: Move to configuration
            _safeFactor = 3.8;
        }

        internal double GetglassTicknes(double lengthWidthRatio, double height) 
        {
            var betaConstant = _glassStrengthConstants.GetMainPanelConstants(lengthWidthRatio).Beta;
            
            var tickness = Math.Sqrt(betaConstant * height * height * height * constant / BendingStress);

            return Math.Ceiling(tickness);
        }
    }
}
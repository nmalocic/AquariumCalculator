using System;

namespace AquariumCalculatorTests
{
    internal class AquariumCatalog
    {
        private GlassTicknessCalculator _glassTickness;
        private GlassCatalog _catalog;

        public AquariumCatalog(GlassTicknessCalculator glassTickness, GlassCatalog catalog)
        {
            _glassTickness = glassTickness;
            _catalog = catalog;
        }

        internal AquariumOffer GetOfferFor(Aquarium aquarium)
        {
            _glassTickness.GetglassTicknes(aquarium.LengthHeightRatio, aquarium.Height);
            throw new NotImplementedException();
        }
    }
}
using Xunit;

namespace AquariumCalculatorTests
{
    public class AquariumOfferTests
    {
        [Fact]
        public void GivenAquarium_GetOffer()
        {

            MainPanelGlassStrengthConstants glasConstants = new MainPanelGlassStrengthConstants();

            GlassTicknessCalculator glassTickness = new GlassTicknessCalculator(glasConstants);
            GlassCatalog glassCatalog = new GlassCatalog();

            AquariumCatalog catalog = new AquariumCatalog(glassTickness, glassCatalog);

            Aquarium aquarium = new Aquarium(50, 50, 50);
            AquariumOffer offer = catalog.GetOfferFor(aquarium);


            Assert.Equal(5, 5);
        }
    }
}

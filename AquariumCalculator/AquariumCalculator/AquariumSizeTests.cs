using System;
using Xunit;

namespace AquariumCalculatorTests
{
    public class AquariumSizeTests
    {
        [Fact]
        public void Given_Aquarium_Size_Returns_Volume()
        {
            int width = 50;
            int length = 50;
            int height = 50;

            Aquarium aq = new Aquarium(length, width, height);

            var volume = aq.Volume;

            Assert.Equal(125, volume);
        }

        [Fact]
        public void Given_Aquarium_Size_Returns_GlassArea()
        {
            int width = 50;
            int length = 50;
            int height = 50;

            Aquarium aq = new Aquarium(length, width, height);
            int glassSize = aq.GlassSize;

            Assert.Equal(12500, glassSize);
        }

        [Fact]
        public void Given_Aquarium_Size_returns_glassArea()
        {
            int width = 50;
            int length = 60;
            int height = 100;

            Aquarium aq = new Aquarium(length, width, height);
            int glassSize = aq.GlassSize;

            Assert.Equal(25000, glassSize);
        }
    }
}

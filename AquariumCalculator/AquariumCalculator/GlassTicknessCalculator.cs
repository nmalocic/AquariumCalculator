using Xunit;

namespace AquariumCalculatorTests
{
    public class GlassTicknessCalculatorTests
    {
        [Fact]
        public void Given_L_H_Ratio_Of_1_Calculate_Glass_Tickness()
        {
            MainPanelGlassStrengthConstants mpgsc = new MainPanelGlassStrengthConstants();
            GlassTicknessCalculator calc = new GlassTicknessCalculator(mpgsc);

            var glassTicknes = calc.GetglassTicknes(1, 1000);

            Assert.Equal(18, glassTicknes);
        }

        [Fact]
        public void Test2()
        {
            MainPanelGlassStrengthConstants mpgsc = new MainPanelGlassStrengthConstants();
            GlassTicknessCalculator calc = new GlassTicknessCalculator(mpgsc);

            var glassTicknes = calc.GetglassTicknes(2.85, 350);

            Assert.Equal(6, glassTicknes);
        }

        [Fact]
        public void Test3()
        {
            MainPanelGlassStrengthConstants mpgsc = new MainPanelGlassStrengthConstants();
            GlassTicknessCalculator calc = new GlassTicknessCalculator(mpgsc);

            var glassTicknes = calc.GetglassTicknes(1.533, 1500);

            Assert.Equal(42, glassTicknes);
        }
    }
}

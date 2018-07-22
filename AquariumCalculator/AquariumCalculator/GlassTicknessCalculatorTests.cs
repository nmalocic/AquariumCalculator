using Xunit;
using Moq;
using AquariumCalculator.Services;
using AquariumCalculator.Contracts;
using AquariumCalculator.Models;

namespace AquariumCalculatorTests
{
  public class GlassTicknessCalculatorTests
  {
    //[Fact]
    //public void Given_L_H_Ratio_Of_1_Calculate_Glass_Tickness()
    //{
    //  Mock<IGlassStrength> mock = new Mock<IGlassStrength>();
    //  mock.Setup(foo => foo.GetStrength(1)).Returns(new AlfaBetaConstants(1.0, 0.022, 0.16));
    //  GlassTicknessCalculator calc = new GlassTicknessCalculator(mock.Object);

    //  var glassTicknes = calc.GetGlassTicknes(1, 1000);

    //  Assert.Equal(18, glassTicknes);
    //}

    //[Fact]
    //public void Test2()
    //{
    //  Mock<IGlassStrength> mock = new Mock<IGlassStrength>();
    //  mock.Setup(foo => foo.GetStrength(2.85)).Returns(new AlfaBetaConstants(3.0, 0.067, 0.37));
    //  GlassTicknessCalculator calc = new GlassTicknessCalculator(mock.Object);

    //  var glassTicknes = calc.GetGlassTicknes(2.85, 350);

    //  Assert.Equal(6, glassTicknes);
    //}

    //[Fact]
    //public void Test3()
    //{
    //  Mock<IGlassStrength> mock = new Mock<IGlassStrength>();
    //  mock.Setup(foo => foo.GetStrength(1.533)).Returns(new AlfaBetaConstants(2.0, 0.056, 0.26));
    //  GlassTicknessCalculator calc = new GlassTicknessCalculator(mock.Object);
    //  var glassTicknes = calc.GetGlassTicknes(1.533, 1500);

    //  Assert.Equal(42, glassTicknes);
    //}
  }
}

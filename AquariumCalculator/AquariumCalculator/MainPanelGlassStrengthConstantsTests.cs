using AquariumCalculator.Models;
using AquariumCalculator.Services;
using Xunit;

namespace AquariumCalculatorTests
{
  /// <summary>
  /// This class is used to test caluclation alpha and beta glass strength contstants
  /// 
  /// Ratio of L/H	Alpha	Beta	
  /// 0.5	            0.003	0.085    		
  /// 0.666        	0.0085	0.1156		
  /// 1.0           	0.022   0.16	
  /// 1.5         	0.042	0.26	
  /// 2.0         	0.056	0.32	
  /// 2.5         	0.063	0.35	
  /// 3.0	            0.067	0.37	
  /// When the ratio is less than 0.5, use Alpha and Beta values for 0.5.
  /// When the ratio is greater than 3, use Alpha and Beta values for 3.
  /// 
  /// </summary>
  public class MainPanelGlassStrengthConstantsTests
  {
    [Theory]
    [InlineData(0.34, 0.085)]
    [InlineData(0.5, 0.085)]
    [InlineData(0.6, 0.1156)]
    [InlineData(0.666, 0.1156)]
    [InlineData(0.8, 0.16)]
    [InlineData(1, 0.16)]
    [InlineData(1.2, 0.26)]
    [InlineData(1.5, 0.26)]
    [InlineData(1.8, 0.32)]
    [InlineData(2, 0.32)]
    [InlineData(2.345, 0.35)]
    [InlineData(2.5, 0.35)]
    [InlineData(2.879, 0.37)]
    [InlineData(3, 0.37)]
    [InlineData(3.012, 0.37)]
    public void Given_The_Ratio_Returns_Beta_Strength(double ratio, double expected)
    {
      MainPanelGlassStrengthConstants mpgsc = new MainPanelGlassStrengthConstants();
      AlfaBetaConstants betaConstant = mpgsc.GetStrength(ratio);

      Assert.Equal(expected, betaConstant.Beta);
    }
  }
}

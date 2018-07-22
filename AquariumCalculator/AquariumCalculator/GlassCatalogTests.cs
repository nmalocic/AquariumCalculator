using AquariumCalculator.Models;
using AquariumCalculator.Services;
using Xunit;

namespace AquariumCalculatorTests
{
  public class GlassCatalogTests
  {
    [Theory]
    [InlineData(4, 14)]
    [InlineData(6, 18)]
    [InlineData(8, 25)]
    [InlineData(10, 31)]
    [InlineData(12, 45)]
    [InlineData(15, 100)]
    [InlineData(20, 100)]
    [InlineData(30, 155)]
    [InlineData(40, 215)]
    [InlineData(50, 300)]
    public void Given_GlassTicknes_GetPrice(double tickness, double expected)
    {
      GlassCatalog glassCatalog = new GlassCatalog();
      GlassPrice price = glassCatalog.GetPrice(tickness);

      Assert.Equal(expected, price.Price);
    }
  }
}

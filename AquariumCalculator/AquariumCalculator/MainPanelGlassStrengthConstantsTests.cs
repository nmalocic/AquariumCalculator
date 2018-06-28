using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AquariumCalculator
{
    public class MainPanelGlassStrengthConstantsTests
    {
        [Fact]
        public void Given_Ration_LowerThen_05_Returns_SameAs__For_05()
        {
            MainPanelGlassStrengthConstants mpgsc = new MainPanelGlassStrengthConstants();
            AlfaBetaConstants betaConstant = mpgsc.GetMainPanelConstants(0.34);

            Assert.Equal(0.085, betaConstant.Beta);
        }
    }
}

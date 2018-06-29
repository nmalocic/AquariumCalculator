using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AquariumCalculator
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
        [Fact]
        public void Given_Ratio_LowerThen_0_5_Returns_SameAs__0_5()
        {
            MainPanelGlassStrengthConstants mpgsc = new MainPanelGlassStrengthConstants();
            AlfaBetaConstants betaConstant = mpgsc.GetMainPanelConstants(0.34);

            Assert.Equal(0.085, betaConstant.Beta);
        }

        [Fact]
        public void Given_Ratio_EqualTo_0_5_Returns_0_5()
        {
            MainPanelGlassStrengthConstants mpgsc = new MainPanelGlassStrengthConstants();
            AlfaBetaConstants betaConstant = mpgsc.GetMainPanelConstants(0.5);

            Assert.Equal(0.085, betaConstant.Beta);
        }

        [Fact]
        public void Given_Ratio_LowerThan_0_666_Returns_SamAs_0_666()
        {
            MainPanelGlassStrengthConstants mpgsc = new MainPanelGlassStrengthConstants();
            AlfaBetaConstants betaConstant = mpgsc.GetMainPanelConstants(0.6);

            Assert.Equal(0.1156, betaConstant.Beta);
        }

        [Fact]
        public void Given_Ratio_Equal_0_666_Returns_0_666()
        {
            MainPanelGlassStrengthConstants mpgsc = new MainPanelGlassStrengthConstants();
            AlfaBetaConstants betaConstant = mpgsc.GetMainPanelConstants(0.666);

            Assert.Equal(0.1156, betaConstant.Beta);
        }

        [Fact]
        public void Given_Ratio_LowerThan_1_Returns_SamAs_1()
        {
            MainPanelGlassStrengthConstants mpgsc = new MainPanelGlassStrengthConstants();
            AlfaBetaConstants betaConstant = mpgsc.GetMainPanelConstants(0.8);

            Assert.Equal(0.16, betaConstant.Beta);
        }

        [Fact]
        public void Given_ration_Equals_1_Returns_1()
        {
            MainPanelGlassStrengthConstants mpgsc = new MainPanelGlassStrengthConstants();
            AlfaBetaConstants betaConstant = mpgsc.GetMainPanelConstants(1);

            Assert.Equal(0.16, betaConstant.Beta);
        }

        [Fact]
        public void Given_Ratio_LowerThan_1_5_Returns_SameAs_1_5()
        {
            MainPanelGlassStrengthConstants mpgsc = new MainPanelGlassStrengthConstants();
            AlfaBetaConstants betaConstant = mpgsc.GetMainPanelConstants(1.2);

            Assert.Equal(0.26, betaConstant.Beta);
        }

        [Fact]
        public void Given_Ratio_Equal_1_5_Returns_1_5()
        {
            MainPanelGlassStrengthConstants mpgsc = new MainPanelGlassStrengthConstants();
            AlfaBetaConstants betaConstant = mpgsc.GetMainPanelConstants(1.5);

            Assert.Equal(0.26, betaConstant.Beta);
        }

        [Fact]
        public void Given_Ratio_LowerThan_2_Returns_SamAs_2()
        {
            MainPanelGlassStrengthConstants mpgsc = new MainPanelGlassStrengthConstants();
            AlfaBetaConstants betaConstant = mpgsc.GetMainPanelConstants(1.8);

            Assert.Equal(0.32, betaConstant.Beta);
        }

        [Fact]
        public void Given_Ratio_Equals_2_Returns_2()
        {
            MainPanelGlassStrengthConstants mpgsc = new MainPanelGlassStrengthConstants();
            AlfaBetaConstants betaConstant = mpgsc.GetMainPanelConstants(2);

            Assert.Equal(0.32, betaConstant.Beta);
        }

        [Fact]
        public void Given_Ratio_LowerThan_2_5_Returns_SameAs_2_5()
        {
            MainPanelGlassStrengthConstants mpgsc = new MainPanelGlassStrengthConstants();
            AlfaBetaConstants betaConstant = mpgsc.GetMainPanelConstants(2.345);

            Assert.Equal(0.35, betaConstant.Beta);
        }

        [Fact]
        public void Given_Ratio_Equals_2_5_Returns_2_5()
        {
            MainPanelGlassStrengthConstants mpgsc = new MainPanelGlassStrengthConstants();
            AlfaBetaConstants betaConstant = mpgsc.GetMainPanelConstants(2.5);

            Assert.Equal(0.35, betaConstant.Beta);
        }

        [Fact]
        public void Given_Ratio_LowerThan_3_Returns_SamAs_3()
        {
            MainPanelGlassStrengthConstants mpgsc = new MainPanelGlassStrengthConstants();
            AlfaBetaConstants betaConstant = mpgsc.GetMainPanelConstants(2.879);

            Assert.Equal(0.37, betaConstant.Beta);
        }

        [Fact]
        public void Given_Ratio_Equals_3_Returns_3()
        {
            MainPanelGlassStrengthConstants mpgsc = new MainPanelGlassStrengthConstants();
            AlfaBetaConstants betaConstant = mpgsc.GetMainPanelConstants(3);

            Assert.Equal(0.37, betaConstant.Beta);
        }

        [Fact]
        public void Given_Ratio_GraterThan_3_Returns_SameAs_3()
        {
            MainPanelGlassStrengthConstants mpgsc = new MainPanelGlassStrengthConstants();
            AlfaBetaConstants betaConstant = mpgsc.GetMainPanelConstants(4);

            Assert.Equal(0.37, betaConstant.Beta);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace AquariumCalculatorTests
{
    /// <summary>
    /// This class is used to caluclate alpha and beta glass strength contstants
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
    internal class MainPanelGlassStrengthConstants : IGlassStrength
    {
        private readonly IEnumerable<AlfaBetaConstants> _mainPanelConstants;
        private readonly AlfaBetaConstants _max = new AlfaBetaConstants(3.0, 0.067, 0.37);

        public MainPanelGlassStrengthConstants()
        {
            List<AlfaBetaConstants> init = new List<AlfaBetaConstants>();
            init.Add(new AlfaBetaConstants(0.5, 0.0003, 0.085));
            init.Add(new AlfaBetaConstants(0.666, 0.0085, 0.1156));
            init.Add(new AlfaBetaConstants(1.0, 0.022, 0.16));
            init.Add(new AlfaBetaConstants(1.5, 0.042, 0.26));
            init.Add(new AlfaBetaConstants(2.0, 0.056, 0.32));
            init.Add(new AlfaBetaConstants(2.5, 0.063, 0.35));
            init.Add(new AlfaBetaConstants(3.0, 0.067, 0.37));

            _mainPanelConstants = init;
        }

        public AlfaBetaConstants GetStrength(double ratio)
        {
            return _mainPanelConstants
                  .OrderBy(x => x.Ratio)
                  .Where(item => item.Ratio >= ratio)
                  .DefaultIfEmpty(_max)
                  .First();
        }
    }
}
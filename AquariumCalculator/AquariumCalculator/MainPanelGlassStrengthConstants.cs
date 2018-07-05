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
        private static readonly IEnumerable<AlfaBetaConstants> _mainPanelConstants;

        static MainPanelGlassStrengthConstants()
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
            // If less than 0, then 0.5 anyway.
            // if more than 2.9, then 3.0 anyway, might as well clamp.
            var clampedRatio = Math.Clamp(ratio, 0d, 2.9d);

            return _mainPanelConstants
                  .OrderBy(x => x.Ratio)
                  .Where(item => item.Ratio >= clampedRatio)
                  .Aggregate((min, next) => min.Ratio < next.Ratio ? min : next);
        }
    }
}
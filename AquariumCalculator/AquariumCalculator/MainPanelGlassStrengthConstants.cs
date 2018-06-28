using System;
using System.Collections.Generic;

namespace AquariumCalculator
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
    internal class MainPanelGlassStrengthConstants
    {
        private readonly Dictionary<double, AlfaBetaConstants> _mainPanelConstants = new Dictionary<double, AlfaBetaConstants>(7);

        public MainPanelGlassStrengthConstants()
        {
            _mainPanelConstants.Add(0.5, new AlfaBetaConstants(0.0003, 0.085));
            _mainPanelConstants.Add(0.666, new AlfaBetaConstants(0.0085, 0.1156));
            _mainPanelConstants.Add(1.0, new AlfaBetaConstants(0.022, 0.16));
            _mainPanelConstants.Add(1.5, new AlfaBetaConstants(0.042, 0.26));
            _mainPanelConstants.Add(2.0, new AlfaBetaConstants(0.056, 0.32));
            _mainPanelConstants.Add(2.5, new AlfaBetaConstants(0.063, 0.35));
            _mainPanelConstants.Add(3.0, new AlfaBetaConstants(0.067, 0.37));
        }

        internal AlfaBetaConstants GetMainPanelConstants(double lengthToHeightRatio)
        {
            if (lengthToHeightRatio <= 0.5)
                return _mainPanelConstants[0.5];

            return null;
        }
    }
}
using System;

namespace AquariumCalculatorTests
{
    public class AlfaBetaConstants
    {
        public AlfaBetaConstants(double ratio, double alpha, double beta)
        {
            if (alpha < 0 || beta < 0 || ratio < 0)
                throw new ArgumentException("Alpha and beta must be greater than zero.");

            Alpha = alpha;
            Beta = beta;
            Ratio = ratio;
        }

        public double Alpha { get; }
        public double Beta { get; }
        public double Ratio { get; }
    }
}
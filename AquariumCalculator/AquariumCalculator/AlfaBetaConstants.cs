using System;

namespace AquariumCalculatorTests
{
    internal class AlfaBetaConstants
    {
        public AlfaBetaConstants(double alpha, double beta)
        {
            if(alpha < 0 || beta < 0)
                throw new ArgumentException("Alpha and beta must be greater than zero.");

            Alpha = alpha;
            Beta = beta;
        }

        public double Alpha { get; }
        public double Beta { get; }
    }
}
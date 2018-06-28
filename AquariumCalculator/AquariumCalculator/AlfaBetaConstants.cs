namespace AquariumCalculator
{
    internal class AlfaBetaConstants
    {
        private double _alpha;
        private double _beta;

        public AlfaBetaConstants(double alpha, double beta)
        {
            _alpha = alpha;
            _beta = beta;
        }

        public double Alpha => _alpha;
        public double Beta => _beta;
    }
}
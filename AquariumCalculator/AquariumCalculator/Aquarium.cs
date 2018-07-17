namespace AquariumCalculatorTests
{
    internal class Aquarium
    {
        private double length;
        private double width;
        private double height;
        private readonly int _toLiters = 1000;

        public Aquarium(double length, double width, double height)
        {
            this.length = length;
            this.width = width;
            this.height = height;
        }

        internal double Volume => length * width * height / _toLiters;
        
        internal double GlassSize => 2 * WidthArea + 2 * LengthArea + BaseArea;

        internal double LengthHeightRatio => length / height;

        internal double Height => height;

        private double WidthArea => width * height;

        private double LengthArea => length * height;

        private double BaseArea => width * length;
    }
}
namespace AquariumCalculatorTests
{
    internal class Aquarium
    {
        private int length;
        private int width;
        private int height;
        private readonly int _toLiters = 1000;

        public Aquarium(int length, int width, int height)
        {
            this.length = length;
            this.width = width;
            this.height = height;
        }

        internal int GetVolume()
        {
            return length * width * height / _toLiters;
        }

        internal int GetGlassSize()
        {
            return 2 * WidthArea + 2 * LengthArea + BaseArea;
        }

        private int WidthArea => width * height;

        private int LengthArea => length * height;

        private int BaseArea => width * length;
    }
}
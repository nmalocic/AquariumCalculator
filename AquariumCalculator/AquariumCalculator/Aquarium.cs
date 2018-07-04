namespace AquariumCalculatorTests
{
    // Made it struct and immutable.
    // No setters existed anyway other than constructor.
    internal struct Aquarium
    {
        public long VolumeMilliliters { get; private set; }
        public double VolumeLiters { get; private set; }
        public int GlassSize { get; private set; }


        public Aquarium(int length, int width, int height)
        {
            VolumeMilliliters = length * width * height;
            VolumeLiters = VolumeMilliliters / 1000d;
            GlassSize = 2 * height * (width + length) + width * length;
        }
    }
}
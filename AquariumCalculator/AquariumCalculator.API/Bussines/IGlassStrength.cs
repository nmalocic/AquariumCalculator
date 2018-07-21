using AquariumCalculator.API.Models;

namespace AquariumCalculator.API.Bussines
{
    public interface IGlassStrength
    {
        AlfaBetaConstants GetStrength(double ratio);
    }
}

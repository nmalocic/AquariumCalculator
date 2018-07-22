using AquariumCalculator.Models;

namespace AquariumCalculator.Contracts
{
    public interface IGlassStrength
    {
        AlfaBetaConstants GetStrength(double ratio);
    }
}

namespace SimulationComplexité.Simulation;

internal static class SumExtensions
{
    public static uint Sum(this IEnumerable<uint> elements)
        => (uint) elements.Select(e => (long) e).Sum();
}
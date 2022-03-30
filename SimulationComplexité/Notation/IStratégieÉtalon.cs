using SimulationComplexité.Simulation.Stratégie;

namespace SimulationComplexité.Notation
{
    internal interface IStratégieÉtalon : IStratégieQualité
    {
        public ushort Note { get; }
    }
}

using SimulationComplexité.Notation;
using SimulationComplexité.Simulation.Stratégie;

namespace SimulationComplexité.Stratégies.Prédéfinies;

internal class StratégieDavidGoodenough : StratégieStateless, IStratégieÉtalon
{
    /// <inheritdoc />
    public override uint MontantInvestiEnQualité(
        uint valeurProduiteBrute,
        uint complexitéAccidentelleActuelle,
        uint scoreProduitActuel,
        ushort coûtDUnDé)
        => 0;

    /// <inheritdoc />
    public ushort Note => 0;
}
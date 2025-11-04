using SimulationComplexité.Simulation.Stratégie;

namespace SimulationComplexité.Stratégies.Prédéfinies;

internal class StratégieDavidGoodenough : StratégieStateless
{
    /// <inheritdoc />
    public override uint MontantInvestiEnQualité(
        uint valeurProduiteBrute,
        uint complexitéAccidentelleActuelle,
        uint scoreProduitActuel,
        ushort coûtDUnDé)
        => 0;

    public override string ToString()
    {
        return "David Goodenough";
    }
}
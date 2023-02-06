using SimulationComplexité.Notation;
using SimulationComplexité.Simulation.Stratégie;

namespace SimulationComplexité.Stratégies.Prédéfinies;

internal class StratégieQuiVaChaptiVaLoin : StratégieStateless, IStratégieÉtalon
{
    /// <inheritdoc />
    public override uint MontantInvestiEnQualité(
        uint valeurProduiteBrute, 
        uint complexitéAccidentelleActuelle,
        uint scoreProduitActuel, 
        ushort coutDUnDé)
    {
        if (complexitéAccidentelleActuelle > valeurProduiteBrute) return valeurProduiteBrute;
        var valeurInvestissableEnProduit = valeurProduiteBrute - complexitéAccidentelleActuelle;

        return complexitéAccidentelleActuelle + valeurInvestissableEnProduit / 2;
    }

    /// <inheritdoc />
    public ushort Note => 10;
}
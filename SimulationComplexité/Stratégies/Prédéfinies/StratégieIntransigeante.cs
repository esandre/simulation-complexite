using SimulationComplexité.Simulation.Stratégie;

namespace SimulationComplexité.Stratégies.Prédéfinies;

internal class StratégieIntransigeante : StratégieStateless
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

    public override string ToString()
    {
        return "Intransigeante";
    }
}
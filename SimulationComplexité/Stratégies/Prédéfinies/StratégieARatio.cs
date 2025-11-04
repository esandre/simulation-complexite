using SimulationComplexité.Simulation.Stratégie;

namespace SimulationComplexité.Stratégies.Prédéfinies;

internal class StratégieARatio : StratégieStateless
{
    private readonly double _pourcentageQualité;

    public StratégieARatio(double pourcentageQualité)
    {
        if (pourcentageQualité < 0) throw new ArgumentOutOfRangeException(nameof(pourcentageQualité));
        if (pourcentageQualité > 100) throw new ArgumentOutOfRangeException(nameof(pourcentageQualité));
        _pourcentageQualité = pourcentageQualité;
    }

    /// <inheritdoc />
    public override uint MontantInvestiEnQualité(
        uint valeurProduiteBrute,
        uint complexitéAccidentelleActuelle,
        uint scoreProduitActuel,
        ushort coutDUnDé)
    {
        var investissementThéorique = (uint)Math.Floor(valeurProduiteBrute * _pourcentageQualité / 100);

        for (var investissementRéel = investissementThéorique; investissementRéel > 0; investissementRéel--)
        {
            var complexitéAccidentelleProduite = (long) valeurProduiteBrute - investissementRéel;
            var complexitéAccidentelleFinale = complexitéAccidentelleProduite + complexitéAccidentelleActuelle - investissementRéel;
            if (complexitéAccidentelleFinale >= 0) return investissementRéel;
        }
        
        return 0;
    }

    public override string ToString()
    {
        return $"Ratio {_pourcentageQualité:00}% qualité";
    }
}
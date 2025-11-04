using SimulationComplexité.Simulation.Stratégie;

namespace SimulationComplexité.Stratégies.Prédéfinies;

internal class StratégieSeuilFixe : StratégieStateless
{
    private readonly StratégieStateless _sousLeSeuil;
    private readonly StratégieStateless _surLeSeuilInclusif;
    private readonly uint _seuil;

    public StratégieSeuilFixe(StratégieStateless sousLeSeuil, StratégieStateless surLeSeuilInclusif, uint seuil)
    {
        _sousLeSeuil = sousLeSeuil;
        _surLeSeuilInclusif = surLeSeuilInclusif;
        _seuil = seuil;
    }

    public override uint MontantInvestiEnQualité(
        uint valeurProduiteBrute, 
        uint complexitéAccidentelleActuelle, 
        uint scoreProduitActuel,
        ushort coûtDUnDé)
    {
        if (complexitéAccidentelleActuelle < _seuil)
            return _sousLeSeuil.MontantInvestiEnQualité(valeurProduiteBrute, complexitéAccidentelleActuelle,
                scoreProduitActuel, coûtDUnDé);

        return _surLeSeuilInclusif.MontantInvestiEnQualité(valeurProduiteBrute, complexitéAccidentelleActuelle,
            scoreProduitActuel, coûtDUnDé);
    }

    public override string ToString()
    {
        return $"Au dessus de {_seuil}, {_surLeSeuilInclusif} sinon {_sousLeSeuil}.";
    }
}
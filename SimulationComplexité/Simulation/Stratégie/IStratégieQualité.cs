namespace SimulationComplexité.Simulation.Stratégie;

internal interface IStratégieQualité
{
    uint MontantInvestiEnQualité(
        uint valeurProduiteBrute, 
        uint complexitéAccidentelleActuelle,
        uint scoreProduitActuel,
        ushort coûtDUnDé);

    IStratégieQualité Fork();
}
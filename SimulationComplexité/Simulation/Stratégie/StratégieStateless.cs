namespace SimulationComplexité.Simulation.Stratégie
{
    internal abstract class StratégieStateless : IStratégieQualité
    {
        /// <inheritdoc />
        public abstract uint MontantInvestiEnQualité(
            uint valeurProduiteBrute,
            uint complexitéAccidentelleActuelle,
            uint scoreProduitActuel,
            ushort coûtDUnDé);

        /// <inheritdoc />
        public IStratégieQualité Fork() => this;
    }
}

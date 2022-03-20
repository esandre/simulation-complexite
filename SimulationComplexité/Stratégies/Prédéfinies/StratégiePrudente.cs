using SimulationComplexité.Notation;
using SimulationComplexité.Simulation.Stratégie;

namespace SimulationComplexité.Stratégies.Prédéfinies
{
    internal class StratégiePrudente : StratégieStateless, IStratégieÉtalon
    {
        /// <inheritdoc />
        public override uint MontantInvestiEnQualité(
            uint valeurProduiteBrute,
            uint complexitéAccidentelleActuelle,
            uint scoreProduitActuel,
            ushort coutDUnDé)
            => valeurProduiteBrute / 2;

        /// <inheritdoc />
        public ushort Note => 8;
    }
}

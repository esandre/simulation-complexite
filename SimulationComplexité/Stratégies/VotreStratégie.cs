using SimulationComplexité.Simulation.Stratégie;
using SimulationComplexité.Stratégies.Prédéfinies;

namespace SimulationComplexité.Stratégies
{
    internal class VotreStratégie : IStratégieQualité
    {
        private static readonly StratégieQuiVaChaptiVaLoin StratégiePrudente = new ();

        /// <inheritdoc />
        public uint MontantInvestiEnQualité(uint valeurProduiteBrute, uint complexitéAccidentelleActuelle, uint scoreProduitActuel, ushort coutDUnDé)
        {
            return 0;
        }

        /// <inheritdoc />
        public IStratégieQualité Fork() => new VotreStratégie();
    }
}

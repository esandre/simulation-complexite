using SimulationComplexité.Simulation.Stratégie;

namespace SimulationComplexité.Stratégies
{
    internal class VotreStratégie : IStratégieQualité
    {
        /// <inheritdoc />
        public uint MontantInvestiEnQualité(uint valeurProduiteBrute, uint complexitéAccidentelleActuelle, uint scoreProduitActuel, ushort coutDUnDé)
        {
            if (valeurProduiteBrute <= 5) return 0;
            if (complexitéAccidentelleActuelle >= valeurProduiteBrute) return valeurProduiteBrute - 1;
            return complexitéAccidentelleActuelle /2;
        }

        /// <inheritdoc />
        public IStratégieQualité Fork() => new VotreStratégie();
    }
}

using SimulationComplexité.Simulation.Stratégie;
using SimulationComplexité.Stratégies.Prédéfinies;

namespace SimulationComplexité.Stratégies
{
    internal class StratégieAxelBORGET : IStratégieQualité
    {
        private static readonly StratégieQuiVaChaptiVaLoin StratégiePrudente = new ();

        /// <inheritdoc />
        public uint MontantInvestiEnQualité(uint valeurProduiteBrute, uint complexitéAccidentelleActuelle, uint scoreProduitActuel, ushort coutDUnDé)
        {
            if (valeurProduiteBrute < 1) return 0;
            if (complexitéAccidentelleActuelle > valeurProduiteBrute && valeurProduiteBrute > 1) return valeurProduiteBrute - 2; 
            if (complexitéAccidentelleActuelle > valeurProduiteBrute) return valeurProduiteBrute;
            var valeurInvestissableEnProduit = valeurProduiteBrute - complexitéAccidentelleActuelle;
            return complexitéAccidentelleActuelle + valeurInvestissableEnProduit / 2;
        }

        /// <inheritdoc />
        public IStratégieQualité Fork() => new StratégieAxelBORGET();
    }
}

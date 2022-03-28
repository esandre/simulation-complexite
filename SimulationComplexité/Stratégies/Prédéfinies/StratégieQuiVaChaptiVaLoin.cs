using SimulationComplexité.Notation;
using SimulationComplexité.Simulation.Stratégie;

namespace SimulationComplexité.Stratégies.Prédéfinies
{
    internal class StratégieQuiVaChaptiVaLoin : StratégieStateless, IStratégieÉtalon
    {
        /// <inheritdoc />
        public override uint MontantInvestiEnQualité(
            uint valeurProduiteBrute, 
            uint complexitéAccidentelleActuelle,
            uint scoreProduitActuel, 
            ushort coutDUnDé)
        {
            if (complexitéAccidentelleActuelle > valeurProduiteBrute)
            {
                return valeurProduiteBrute;
            }
            var valeurInvestissableEnProduit = valeurProduiteBrute - complexitéAccidentelleActuelle;
            var enQualité = complexitéAccidentelleActuelle + valeurInvestissableEnProduit / 2;
            return enQualité;
        }

        /// <inheritdoc />
        public ushort Note => 10;
    }
}

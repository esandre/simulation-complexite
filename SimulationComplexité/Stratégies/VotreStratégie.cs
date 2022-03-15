using SimulationComplexité.Simulation.Stratégie;

namespace SimulationComplexité.Stratégies
{
    internal class StratégieClermontGeoffrey : IStratégieQualité
    {
        int iterations = 0;
        /// <inheritdoc />
        public uint MontantInvestiEnQualité(uint valeurProduiteBrute, uint complexitéAccidentelleActuelle, uint scoreProduitActuel, ushort coutDUnDé)
        {
            // BON COURAGE
            if (complexitéAccidentelleActuelle > valeurProduiteBrute) {
                return 0;
            } 

            if (iterations % 2 == 0 ) {
                iterations++;
                return valeurProduiteBrute / 2;
            }

            var valeurInvestissableEnProduit = valeurProduiteBrute - complexitéAccidentelleActuelle;
            iterations++;
            return complexitéAccidentelleActuelle + valeurInvestissableEnProduit / 2;
        }

        /// <inheritdoc />
        public IStratégieQualité Fork() => new StratégieClermontGeoffrey();
    }
}

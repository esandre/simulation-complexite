using SimulationComplexité.Simulation.Stratégie;

namespace SimulationComplexité.Stratégies
{
    internal class JaphetNamdegone_Production : IStratégieQualité
    {
        /// <inheritdoc />
        public uint MontantInvestiEnQualité(uint valeurProduiteBrute, uint complexitéAccidentelleActuelle, uint scoreProduitActuel, ushort coutDUnDé)
        {
            var valeurInvestissableEnProduit = valeurProduiteBrute - complexitéAccidentelleActuelle;
            var valeur = valeurProduiteBrute % 2;
            if (valeur == 0) return valeurProduiteBrute / 2;
            else
            {

                if (complexitéAccidentelleActuelle > valeurProduiteBrute)
                    return valeurProduiteBrute - 1  ;
                return complexitéAccidentelleActuelle + valeurInvestissableEnProduit / 2;

            }
        }

        /// <inheritdoc />
        public IStratégieQualité Fork() => new JaphetNamdegone_Production();
    }
}

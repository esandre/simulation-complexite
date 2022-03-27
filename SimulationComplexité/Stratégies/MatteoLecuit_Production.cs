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
            var maximumInvestissable = StratégiePrudente.MontantInvestiEnQualité(
                valeurProduiteBrute, 
                complexitéAccidentelleActuelle, 
                scoreProduitActuel, 
                coutDUnDé);

            var complexitéTotaleInitale = scoreProduitActuel + complexitéAccidentelleActuelle;

            (uint InvestissementQualité, uint NombreDésEntropieProjeté, uint MontantProduit) meilleurInvestissement = 
                (0, (complexitéTotaleInitale + valeurProduiteBrute * 2) / coutDUnDé, valeurProduiteBrute);
            
            for (uint montantInvestiEnQualité = 1; montantInvestiEnQualité <= maximumInvestissable; montantInvestiEnQualité++)
            {
                var montantInvestiEnProduit = Convert.ToUInt32(valeurProduiteBrute - montantInvestiEnQualité);
                var complexitéProduite = montantInvestiEnProduit * 2;

                var complexitéTotaleProjetée =
                    Convert.ToUInt32(complexitéTotaleInitale + complexitéProduite - montantInvestiEnQualité);

                var nombreDésEntropieProjeté = complexitéTotaleProjetée / coutDUnDé;

                if (nombreDésEntropieProjeté < meilleurInvestissement.NombreDésEntropieProjeté
                    || nombreDésEntropieProjeté == meilleurInvestissement.NombreDésEntropieProjeté
                    && montantInvestiEnProduit > meilleurInvestissement.MontantProduit)
                    meilleurInvestissement = (montantInvestiEnQualité, nombreDésEntropieProjeté, montantInvestiEnProduit);
            }

            return meilleurInvestissement.InvestissementQualité;
        }

        /// <inheritdoc />
        public IStratégieQualité Fork() => new VotreStratégie();
    }
}

using SimulationComplexité.Simulation.Stratégie;

namespace SimulationComplexité.Stratégies
{
    internal class Valentin_Production : IStratégieQualité
    {
        /// <inheritdoc />
        public uint MontantInvestiEnQualité(uint valeurProduiteBrute, uint complexitéAccidentelleActuelle, uint scoreProduitActuel, ushort coutDUnDé)
        {
            if (valeurProduiteBrute < 1) // on peut rien investir de toute façon
                return 0;
            
            uint investissementQualité; // StratégieQuiVaChaptiVaLoin - qualité max
            if (complexitéAccidentelleActuelle > valeurProduiteBrute)
                investissementQualité = valeurProduiteBrute;
            else
            {
                var valeurInvestissableEnProduit = valeurProduiteBrute - complexitéAccidentelleActuelle;
                investissementQualité = complexitéAccidentelleActuelle + valeurInvestissableEnProduit / 2;
            }
            
            var investissementProduit = valeurProduiteBrute - investissementQualité;
            var prochainScoreProduit = scoreProduitActuel + investissementProduit;
            if (prochainScoreProduit == scoreProduitActuel) // si on y gagne rien
            {
                investissementQualité = valeurProduiteBrute % 2 == 0 ? valeurProduiteBrute / 2 : 0; // on divise par 2 si on peut sinon pas de qualité sur ce tour
            }
            
            return investissementQualité;
        }

        /// <inheritdoc />
        public IStratégieQualité Fork() => new Valentin_Production();
    }
}

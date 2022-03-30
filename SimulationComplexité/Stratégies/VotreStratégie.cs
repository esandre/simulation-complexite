using SimulationComplexité.Simulation.Stratégie;

namespace SimulationComplexité.Stratégies
{
    internal class VotreStratégie : IStratégieQualité
    {
        /// <inheritdoc />
        public uint MontantInvestiEnQualité(uint valeurProduiteBrute,
            uint complexitéAccidentelleActuelle, uint scoreProduitActuel, ushort coutDUnDé)
        {

            var valeurInvestissableEnProduit = valeurProduiteBrute - complexitéAccidentelleActuelle;


            for (uint i = valeurProduiteBrute; i > 0; i--)
            {
                var qualiteactuelle = valeurProduiteBrute - i;
                var prod = i;
                var qualfuture = complexitéAccidentelleActuelle - qualiteactuelle + prod;
                var future = (qualfuture + scoreProduitActuel) / 180;
                var passe = (complexitéAccidentelleActuelle + scoreProduitActuel) / 180;
                if (qualfuture < valeurProduiteBrute)
                {
                    if (future < passe && qualfuture >= 0) return qualiteactuelle;
                }

            }



            for (uint i = valeurProduiteBrute; i > 0; i--)
            {
                var qualiteactuelle = valeurProduiteBrute - i;
                var prod = i;
                var qualfuture = complexitéAccidentelleActuelle - qualiteactuelle + prod;

                if (qualfuture <= 1) return qualiteactuelle;


            }






            return 0;

        }

        /// <inheritdoc />
        public IStratégieQualité Fork() => new VotreStratégie();
    }
}
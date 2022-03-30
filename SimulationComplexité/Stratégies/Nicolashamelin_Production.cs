using SimulationComplexité.Simulation.Stratégie;
using SimulationComplexité.Stratégies.Prédéfinies;

namespace SimulationComplexité.Stratégies
{
    internal class NicolasHamelin_Production : IStratégieQualité
    {
        private static readonly StratégieQuiVaChaptiVaLoin StratégiePrudente = new ();

        /// <inheritdoc />
        public uint MontantInvestiEnQualité(
            uint valeurProduiteBrute,
            uint complexitéAccidentelleActuelle,
            uint scoreProduitActuel,
            ushort coutDUnDé)
        {

            uint montantInvestiEnQUalité;
            uint valeurInvestissableEnProduit = valeurProduiteBrute - complexitéAccidentelleActuelle;

            if (complexitéAccidentelleActuelle < valeurProduiteBrute)
            {
                montantInvestiEnQUalité = complexitéAccidentelleActuelle + valeurInvestissableEnProduit / 2;

                return montantInvestiEnQUalité;
            }
            else
            {
                if (complexitéAccidentelleActuelle < scoreProduitActuel)
                {
                    if (complexitéAccidentelleActuelle < 5)
                    {
                        montantInvestiEnQUalité = valeurProduiteBrute;

                        return montantInvestiEnQUalité;
                    }
                    else if(complexitéAccidentelleActuelle < 10)
                    {
                        montantInvestiEnQUalité = valeurProduiteBrute / 2;

                        return montantInvestiEnQUalité;
                    } else
                    {
                        montantInvestiEnQUalité = valeurProduiteBrute / 3;
                        return montantInvestiEnQUalité;
                    }
                }
                else
                {
                    montantInvestiEnQUalité = valeurProduiteBrute / 2;

                    return montantInvestiEnQUalité;
                }

            }   
        }

        public IStratégieQualité Fork() => new NicolasHamelin_Production();
    }
}

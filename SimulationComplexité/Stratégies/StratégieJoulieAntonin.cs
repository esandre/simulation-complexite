using SimulationComplexité.Simulation.Stratégie;

namespace SimulationComplexité.Stratégies
{
    internal class StratégieJoulieAntonin : IStratégieQualité
    {

        /// <inheritdoc />
        public uint MontantInvestiEnQualité(uint valeurProduiteBrute, uint complexitéAccidentelleActuelle, uint scoreProduitActuel, ushort coutDUnDé)
        {
            uint investissementQualité = 0;

            decimal entropie = (scoreProduitActuel + complexitéAccidentelleActuelle) / 180;

            uint entropieHigher = (uint)Math.Floor(entropie);

            if (complexitéAccidentelleActuelle <= valeurProduiteBrute)
            {
                if (complexitéAccidentelleActuelle < valeurProduiteBrute)
                {
                    investissementQualité = complexitéAccidentelleActuelle;
                }
                else
                {
                    investissementQualité = valeurProduiteBrute - 1;
                }

                var différenceComplexitéAdditionnelle = valeurProduiteBrute - investissementQualité;

                var complexitéPotentielle = complexitéAccidentelleActuelle + différenceComplexitéAdditionnelle;

                if ((complexitéPotentielle + différenceComplexitéAdditionnelle) / 180 <= entropieHigher)
                {
                    return investissementQualité;
                }
                else
                {
                    while ((complexitéPotentielle + différenceComplexitéAdditionnelle) / 180 < entropieHigher + 1 || investissementQualité < valeurProduiteBrute + 1)
                    {
                        investissementQualité--;
                    }

                    return investissementQualité;
                }
            }
            else
            {
                if (valeurProduiteBrute > 1)
                {
                    investissementQualité = valeurProduiteBrute - 1;
                    return investissementQualité;
                }

            }

            return investissementQualité;

        }

        /// <inheritdoc />
        public IStratégieQualité Fork() => new StratégieJoulieAntonin();
    }
}

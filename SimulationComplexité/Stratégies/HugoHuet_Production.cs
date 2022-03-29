using SimulationComplexité.Simulation.Stratégie;
using SimulationComplexité.Stratégies.Prédéfinies;

namespace SimulationComplexité.Stratégies
{
    internal class HugoHuet_Production : IStratégieQualité
    {
        private static readonly StratégieQuiVaChaptiVaLoin StratégiePrudente = new ();

        public uint MontantInvestiEnQualité(uint valeurProduiteBrute, uint complexitéAccidentelleActuelle, uint scoreProduitActuel, ushort coutDUnDé)
        {
            uint nombreDeDéEntropieActuel = (complexitéAccidentelleActuelle + scoreProduitActuel) / coutDUnDé;

            uint qualite = 0;
            uint qualitéMax = valeurProduiteBrute;

            //Attention si complexité < valeur produite on ne peut pas tout investire en qualité
            if (complexitéAccidentelleActuelle < valeurProduiteBrute)
            {
                qualitéMax = qualitéInvestieMax(valeurProduiteBrute, complexitéAccidentelleActuelle);
            }
            uint feature = valeurProduiteBrute - qualitéMax;
            decimal lowerDéEntropiePotentiel = Convert.ToDecimal((feature - qualitéMax + complexitéAccidentelleActuelle) + (feature + scoreProduitActuel)) / coutDUnDé;

            //si dès le minimum de nouvelle feature on est obligé de passser à un dé entropie en plus
            if (lowerDéEntropiePotentiel > nombreDeDéEntropieActuel + 1)
            {
                //on fait moitier moitier
                qualite = qualitéMax / 2;
            }
            else //si non on essaye de tendre vers 0 en complexité
            {
                uint lowerComplexitéPotetielle = complexitéAccidentelleActuelle + valeurProduiteBrute;

                for (uint qualiteTest = 1; qualiteTest < qualitéMax; qualiteTest++)
                {
                    uint featureTest = valeurProduiteBrute - qualiteTest;
                    //complexité potentielle obligatoirement positive
                    if (isComplexitéPotentiellePositive(qualiteTest, valeurProduiteBrute, complexitéAccidentelleActuelle))
                    {
                        uint complexitéPotetielle = featureTest - qualiteTest + complexitéAccidentelleActuelle;
                        uint scoreProduitPotentiel = featureTest + scoreProduitActuel;
                        decimal nombreDéEntropiePotentiel = Convert.ToDecimal(complexitéPotetielle + scoreProduitPotentiel) / coutDUnDé;

                        if (complexitéPotetielle < lowerComplexitéPotetielle && nombreDéEntropiePotentiel < nombreDeDéEntropieActuel + 1)
                        {
                            qualite = qualiteTest;
                            lowerComplexitéPotetielle = complexitéPotetielle;
                        }
                    }
                }
            }
            // BON COURAGE
            return qualite;
        }

        private bool isComplexitéPotentiellePositive(uint qualité, uint valeurProduiteBrute, uint complexitéAccidentelleActuelle)
        {
            return qualité < valeurProduiteBrute - qualité + complexitéAccidentelleActuelle;
        }

        private uint qualitéInvestieMax(uint valeurProduiteBrute, uint complexitéAccidentelleActuelle)
        {
            uint qualitéMax = 0;
            for (uint qualitéTesté = 0; qualitéTesté < valeurProduiteBrute; qualitéTesté++)
            {
                bool isComplexitéPotentiellePositive = this.isComplexitéPotentiellePositive(qualitéTesté, valeurProduiteBrute, complexitéAccidentelleActuelle);
                if (isComplexitéPotentiellePositive)
                {
                    qualitéMax = qualitéTesté;
                }
            }
            return qualitéMax;
        }

        /// <inheritdoc />
        public IStratégieQualité Fork() => new HugoHuet_Production();
    }
}

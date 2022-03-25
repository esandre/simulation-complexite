using SimulationComplexité.Simulation.Stratégie;

namespace SimulationComplexité.Stratégies
{
    internal class ClémentSecklerStratégieDeux : IStratégieQualité
    {
        uint qualité = 0;
        uint scoreTotal = 0;
        /// <inheritdoc />
        public uint MontantInvestiEnQualité(uint valeurProduiteBrute,
            uint complexitéAccidentelleActuelle,
            uint scoreProduitActuel,
            ushort coutDUnDé)
        {
            if (complexitéAccidentelleActuelle >= valeurProduiteBrute)
            {
                qualité = valeurProduiteBrute;
                if (scoreProduitActuel == scoreTotal)
                {
                    qualité = (uint)(valeurProduiteBrute * 0.5);
                }
                if (valeurProduiteBrute < 10)
                {
                    qualité = 0;
                }
            }
            else
            {
                qualité = bestValueForDice( valeurProduiteBrute,
                    complexitéAccidentelleActuelle,
                    scoreProduitActuel,
                    coutDUnDé);
            }

            scoreTotal = scoreProduitActuel;
            
            return qualité;
        }
        public uint bestValueForDice(uint valeurProduiteBrute,
            uint complexitéAccidentelleActuelle,
            uint scoreProduitActuel,
            ushort coutDUnDé)
        {
            uint nombreDeDéNégatifActuel = scoreProduitActuel / coutDUnDé;
            uint complexitéMax = (6 * (6 - nombreDeDéNégatifActuel));
            if (complexitéMax < 12)
            {
                complexitéMax = 12;
            }

            if (complexitéAccidentelleActuelle > 8) 
            {
                double valeurProduiteBruteSelonDéeNégatif = 0.1 * nombreDeDéNégatifActuel;
                if (valeurProduiteBruteSelonDéeNégatif > 0.4)
                {
                    valeurProduiteBruteSelonDéeNégatif = 0.5;
                }

                qualité = stratégieComplexitéEgaleZéro(valeurProduiteBrute,valeurProduiteBruteSelonDéeNégatif);
                
                if ((scoreProduitActuel+complexitéAccidentelleActuelle) > (coutDUnDé * 6))
                {
                    qualité = 0; 
                }
            }
            else
            {
                qualité = stratégieComplexitéDifférentDeZéro(valeurProduiteBrute, complexitéAccidentelleActuelle);
                
            }

            uint nombreDeDéNégatifFutur = (uint)(
                    (scoreProduitActuel +  qualité)
                    / coutDUnDé);

            if (nombreDeDéNégatifActuel != nombreDeDéNégatifFutur)
            {
                qualité = 0;
            }

            

            return qualité;
        }

        public uint stratégieComplexitéEgaleZéro(uint valeurProduiteBrute, double test)
        {
            return (uint)(valeurProduiteBrute * (0.5-test));
        }
        public uint stratégieComplexitéDifférentDeZéro(uint valeurProduiteBrute, uint complexitéAccidentelleActuelle)
        {
            uint qualité = complexitéAccidentelleActuelle + (valeurProduiteBrute - complexitéAccidentelleActuelle) / 2;
            return qualité;
        }

        public uint maxValue(uint nombreDeDéNégatifActuel)
        {
            return 6-nombreDeDéNégatifActuel;
        }
        /// <inheritdoc />
        public IStratégieQualité Fork() => new ClémentSecklerStratégieDeux();
    }
}

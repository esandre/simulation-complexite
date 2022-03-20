using SimulationComplexité.Simulation;

namespace SimulationComplexité.Stratégies
{
    internal class VotreStratégie : IStratégieQualité
    {
        public uint complexityAll = 0;
        /// <inheritdoc />
        public uint MontantInvestiEnQualité(uint valeurProduiteBrute,
            uint complexitéAccidentelleActuelle,
            uint scoreProduitActuel,
            ushort coutDUnDé)
        {
            Console.WriteLine(valeurProduiteBrute);
            Console.WriteLine(complexitéAccidentelleActuelle);
            Console.WriteLine(scoreProduitActuel);
            Console.WriteLine(coutDUnDé);

            uint returnValeur = 0;
            if (complexitéAccidentelleActuelle < 50)
            {
                returnValeur = 0;
            }
            else
            {
                returnValeur = bestValueForDice(valeurProduiteBrute,
                    complexitéAccidentelleActuelle,
                    scoreProduitActuel,
                    coutDUnDé);
            }

            this.complexityAll = scoreProduitActuel - returnValeur + complexitéAccidentelleActuelle;

            return returnValeur;
        }
        public uint bestValueForDice(uint valeurProduiteBrute,
            uint complexitéAccidentelleActuelle,
            uint scoreProduitActuel,
            ushort coutDUnDé)
        {
            
            uint numberDiceActually = scoreProduitActuel;
            if (this.complexityAll < 180)
            {
                if((180 - this.complexityAll) > complexitéAccidentelleActuelle)
                {
                    if (valeurProduiteBrute > complexitéAccidentelleActuelle)
                    {
                        numberDiceActually = complexitéAccidentelleActuelle;
                    }
                    else
                    {
                        numberDiceActually = valeurProduiteBrute;
                    }
                }
            }
            else if (this.complexityAll < 360)
            {
                if ((360 - this.complexityAll) > complexitéAccidentelleActuelle)
                {
                    if (valeurProduiteBrute > complexitéAccidentelleActuelle)
                    {
                        numberDiceActually = complexitéAccidentelleActuelle;
                    }
                    else
                    {
                        numberDiceActually = valeurProduiteBrute;
                    }
                }
            }
            else if (this.complexityAll < 540)
            {
                if ((540 - this.complexityAll) > complexitéAccidentelleActuelle)
                {
                    if (valeurProduiteBrute > complexitéAccidentelleActuelle)
                    {
                        numberDiceActually = complexitéAccidentelleActuelle;
                    }
                    else
                    {
                        numberDiceActually = valeurProduiteBrute;
                    }
                }
            }
            else if (this.complexityAll < 720)
            {
                if ((720 - this.complexityAll) > complexitéAccidentelleActuelle)
                {
                    if (valeurProduiteBrute > complexitéAccidentelleActuelle)
                    {
                        numberDiceActually = complexitéAccidentelleActuelle;
                    }
                    else
                    {
                        numberDiceActually = valeurProduiteBrute;
                    }
                }
            }
            else
            {
                numberDiceActually = valeurProduiteBrute;   
            }
            return numberDiceActually;
        }
    }
}

using SimulationComplexité.Simulation.Stratégie;
using SimulationComplexité.Stratégies.Prédéfinies;

namespace SimulationComplexité.Stratégies
{
    internal class VotreStratégie : IStratégieQualité
    {
        /// <inheritdoc />
        public uint MontantInvestiEnQualité(uint valeurProduiteBrute, uint complexitéAccidentelleActuelle, uint scoreProduitActuel, ushort coutDUnDé)
        {
            // BON COURAGE
            uint nombreDeDes = (complexitéAccidentelleActuelle + scoreProduitActuel) / coutDUnDé;

            if (complexitéAccidentelleActuelle > valeurProduiteBrute)
            {
                var feature = valeurProduiteBrute % coutDUnDé;
                //return valeurProduiteBrute > 2 ? valeurProduiteBrute - feature : valeurProduiteBrute; //1046 à peu près
                return valeurProduiteBrute - feature; //1060 environ et 7.5 val/itération
            }

            uint produit;
            ; //valeur des dés d'entopie actuels
            uint valeurANePasDepasser = nombreDeDes + 1; // valeur qu'on veut éviter de dépasser pour pas perdre un dé
            double ratio = valeurANePasDepasser; //valeur à éviter de dépasser pour pas perdre un dé

            uint valeurAInvestir = 0;

            int scoreProduitTotal;
            int complexiteAccidentelle;
            int complexiteaccidentelleTotale;
            uint complexiteTotale;

            for (uint investQualite = 0; investQualite <= valeurProduiteBrute; investQualite++)
            {
                //produit = valeur brute - ce qu'on met dans qualité
                produit = valeurProduiteBrute - investQualite;

                //Score produit total =  produit actuel + produit investi
                scoreProduitTotal = (int)(scoreProduitActuel + produit);

                //Complexité accidentelle = produi investi - investissement qualité
                complexiteAccidentelle = (int)(produit - investQualite);

                //complexité accidentelle totale = complexité accidentelle actuelle + complexité accidentelle
                complexiteaccidentelleTotale = (int)complexitéAccidentelleActuelle + complexiteAccidentelle;

                //Score Total de complexité = Score Prosuit + Complexité accidentelle
                complexiteTotale = (uint)(scoreProduitTotal + complexiteaccidentelleTotale);

                //Résutat de la division pour voir si on perd un dé ou pas
                var result = (double)complexiteTotale / coutDUnDé;


                // complexiteAccidentelle + complexitéAccidentelleActuelle >= 3 pour un score inférieur mais valeur/itération de 8
                if (result < valeurANePasDepasser && complexiteAccidentelle + complexitéAccidentelleActuelle >= 2 && result <= ratio)
                {
                    valeurAInvestir = investQualite;
                }
            }

            return valeurAInvestir != 0 ? valeurAInvestir : valeurProduiteBrute / 2;
        }

        /// <inheritdoc />
        public IStratégieQualité Fork() => new VotreStratégie();
    }
}

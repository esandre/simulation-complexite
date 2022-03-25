using SimulationComplexité.Simulation.Stratégie;

namespace SimulationComplexité.Stratégies
{
    internal class VotreStratégie : IStratégieQualité
    {
        public uint MontantInvestiEnQualité(uint valeurProduiteBrute, uint complexitéAccidentelleActuelle, uint scoreProduitActuel, ushort coutDUnDé)
        {
            /// Somme de (complexitéAccidentelleActuelle + scoreProduitActuel)
            uint complexiteTotale = complexitéAccidentelleActuelle + scoreProduitActuel;
            double nombreDeDesEntropie = complexiteTotale / coutDUnDé;
            //Console.WriteLine("Complexité totale : " + complexiteTotale + " avec un Score de " + scoreProduitActuel + " et complexité accidentelle de " + complexitéAccidentelleActuelle);
            //Console.WriteLine("nb de dés : " + nombreDeDesEntropie);

            /// Strategie que j'utilise
            StyleStrategie styleStrategie = setMaStrategie(nombreDeDesEntropie);
            if (styleStrategie == StyleStrategie.PasDeComplexite)
            {
                //Console.WriteLine("Ma stratégie est : pas de complex");
                uint valeurInvestitEnQualite = 0;
                uint resteValeurProduiteBrute = 0;

                if (complexitéAccidentelleActuelle > valeurProduiteBrute)
                {
                    return valeurProduiteBrute;
                }

                valeurInvestitEnQualite = complexitéAccidentelleActuelle;

                resteValeurProduiteBrute = valeurProduiteBrute - complexitéAccidentelleActuelle;

                if (resteValeurProduiteBrute < 2)
                {
                    return valeurInvestitEnQualite;
                }

                if (resteValeurProduiteBrute % 2 == 0)
                {
                    valeurInvestitEnQualite += resteValeurProduiteBrute / 2;
                }
                else
                {
                    valeurInvestitEnQualite += resteValeurProduiteBrute / 2 - 1;
                }

                return valeurInvestitEnQualite;
            }

            if (styleStrategie == StyleStrategie.MinimumDeProduit)
            {
                //Console.WriteLine("Ma stratégie est : 1 en prod");
                if (valeurProduiteBrute == 1 || valeurProduiteBrute == 0)
                {
                    return 0;
                }

                if (valeurProduiteBrute == 2)
                {
                    return 1;
                }

                uint valeurInvestitEnQualite = 0;
                uint resteValeurProduiteBrute = valeurProduiteBrute - 1;
                uint compteur = 0;

                if (resteValeurProduiteBrute <= complexitéAccidentelleActuelle)
                {
                    return resteValeurProduiteBrute;
                }

                 

                while (resteValeurProduiteBrute > complexitéAccidentelleActuelle + compteur)
                {
                    //Console.WriteLine("reste : " + resteValeurProduiteBrute + " pour une compe acci actuel de " + complexitéAccidentelleActuelle);
                    compteur += 2;
                    valeurInvestitEnQualite += 1;
                }
                return ((resteValeurProduiteBrute + valeurInvestitEnQualite) - compteur);
            }
            //Console.WriteLine("Ma stratégie est : tous en production");
            return 0;

        }

        public IStratégieQualité Fork() => new VotreStratégie();

        private StyleStrategie setMaStrategie(double nombreDeDesEntropie)
        {
            if (nombreDeDesEntropie < 5.0)
            {
                return StyleStrategie.PasDeComplexite;
            }

            if (nombreDeDesEntropie < 6.0)
            {
                return StyleStrategie.MinimumDeProduit;
            }

            return StyleStrategie.TousEnProduction;
        }
    }
}

enum StyleStrategie
{
    /// L'objectif est de ne pas avoir de complexite
    /// ou le moins possible
    PasDeComplexite,

    /// Essayer de toujour mettre au moins 1 en qualite
    ///quand c'est possible
    MinimumDeProduit,
    
    /// Mettre tous les points quand on en a en production
    TousEnProduction,
}
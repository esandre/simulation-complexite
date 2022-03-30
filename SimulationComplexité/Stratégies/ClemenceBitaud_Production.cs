using SimulationComplexité.Simulation.Stratégie;

namespace SimulationComplexité.Stratégies
{
    internal class VotreStratégie : IStratégieQualité
    {
        /// <inheritdoc />
        public uint MontantInvestiEnQualité(
            uint valeurProduiteBrute, 
            uint complexitéAccidentelleActuelle,
            uint scoreProduitActuel, 
            ushort coutDUnDé)
        {
            
            uint complexiteTotale = complexitéAccidentelleActuelle + scoreProduitActuel;
            double nombreDeDesEntropie = complexiteTotale / coutDUnDé;
            
            StyleStrategie styleStrategie = setMaStrategie(nombreDeDesEntropie);
            uint valeurInvestitEnQualite = 0;
                uint resteValeurProduiteBrute = 0;
            if (styleStrategie == StyleStrategie.PasDeComplexite)
            {
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
            
            if (valeurProduiteBrute == 1 || valeurProduiteBrute == 0)
            {
                return 0;
            }

            if (valeurProduiteBrute == 2)
            {
                return 1;
            }

            valeurInvestitEnQualite = 0;
            resteValeurProduiteBrute = valeurProduiteBrute - 1;
            uint compteur = 0;

            if (resteValeurProduiteBrute <= complexitéAccidentelleActuelle)
            {
                return resteValeurProduiteBrute;
            }

                

            while (resteValeurProduiteBrute > complexitéAccidentelleActuelle + compteur)
            {
                compteur += 2;
                valeurInvestitEnQualite += 1;
            }
            return ((resteValeurProduiteBrute + valeurInvestitEnQualite) - compteur);
        }

        /// <inheritdoc />
        public IStratégieQualité Fork() => new VotreStratégie();
        
        private StyleStrategie setMaStrategie(double nombreDeDesEntropie)
        {
            if (nombreDeDesEntropie < 5.0)
            {
                return StyleStrategie.PasDeComplexite;
            }

            return StyleStrategie.MinimumDeProduit;
        }
    }
    
    enum StyleStrategie
    {
        PasDeComplexite,
        MinimumDeProduit,
    }
}

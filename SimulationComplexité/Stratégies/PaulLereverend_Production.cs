using SimulationComplexité.Simulation.Stratégie;
using SimulationComplexité.Stratégies.Prédéfinies;

namespace SimulationComplexité.Stratégies
{
    internal class PaulLereverend_Production : IStratégieQualité
    {
        private static readonly StratégieQuiVaChaptiVaLoin StratégiePrudente = new ();

        /// <inheritdoc />
        public uint MontantInvestiEnQualité(uint valeurProduiteBrute, uint complexitéAccidentelleActuelle, uint scoreProduitActuel, ushort coutDUnDé)
        {
            // Conversion des variables, plus simple pour le travail
            double valeurProduiteBruteDouble = Convert.ToDouble(valeurProduiteBrute);
            double complexiteAccidentelleActuelleDouble = Convert.ToDouble(complexitéAccidentelleActuelle);
            double scoreProduitActuelDouble = Convert.ToDouble(scoreProduitActuel);
            
            double valeurDesARetirer = ((Convert.ToDouble(scoreProduitActuel + complexitéAccidentelleActuelle))) / coutDUnDé ; //2,6
            double valeurAvantDeRetirerLeProchainDes = (coutDUnDé - (valeurDesARetirer - Math.Truncate(valeurDesARetirer)) * coutDUnDé) -1 ;

            double nbDesEntropie = (complexiteAccidentelleActuelleDouble + scoreProduitActuelDouble) / coutDUnDé;

            //Si on peut blinder le produit sans enlever un dés supplémentaire
            if (valeurAvantDeRetirerLeProchainDes > valeurProduiteBrute * 2)
            {
                return 0;
            }
            
            //A la fin on blinde le produit pour ne pas vivre éternellement
            if (complexitéAccidentelleActuelle >= valeurProduiteBrute && valeurProduiteBrute > 0) return valeurProduiteBrute - 1;
            
            // Formule pour avoir la qualité la plus optimale en restant le plus près possible de 180 -> A = (A - (B+A)/3) 
            double qualite = Math.Ceiling(valeurProduiteBruteDouble -
                                       ((valeurAvantDeRetirerLeProchainDes + valeurProduiteBruteDouble) / 3));
            
            double produit = valeurProduiteBruteDouble - qualite;

            // On augmente progressivement la part alloué à la qualité à mesure que le nombre de dés augmente à condition de ne pas en allouer trop (erreur)
            if (qualite + (produit / (12 - nbDesEntropie)) < complexiteAccidentelleActuelleDouble + (produit))
            {
                qualite += produit / (12 - nbDesEntropie);
                produit = valeurProduiteBruteDouble - qualite;
            }
            
            // Si le process est obligé d'enlever un dés supplémentaire, on blinde le produit
            if (qualite > complexiteAccidentelleActuelleDouble + (produit))
            {
                return 0;
            }
            return Convert.ToUInt16(qualite);
            
        }
        /// <inheritdoc />
        public IStratégieQualité Fork() => new PaulLereverend_Production();
        
    }
}

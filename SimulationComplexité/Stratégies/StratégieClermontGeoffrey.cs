using SimulationComplexité.Simulation.Stratégie;

namespace SimulationComplexité.Stratégies
{
    internal class StratégieClermontGeoffrey : IStratégieQualité
    {
        int iterations = 0;
        /// <inheritdoc />
        public uint MontantInvestiEnQualité(uint valeurProduiteBrute, uint complexitéAccidentelleActuelle, uint scoreProduitActuel, ushort coutDUnDé)
        {
            // BON COURAGE
            /*if (complexitéAccidentelleActuelle > valeurProduiteBrute) {
                //Console.WriteLine(scoreProduitActuel + " à l'iteration : " + iterations);
                return 0;
            }

            if (iterations % 10 == 0 ) {
                iterations++;
                //Console.WriteLine(scoreProduitActuel + " à l'iteration : " + iterations);
                return valeurProduiteBrute / 2;
            }

            //Console.WriteLine(scoreProduitActuel + " à l'iteration : " + iterations);

            var valeurInvestissableEnProduit = valeurProduiteBrute - complexitéAccidentelleActuelle;
            iterations++;
            return complexitéAccidentelleActuelle + valeurInvestissableEnProduit / 2; */
            
            uint valeurQualité = 0;

            if (iterations == 0) {
                valeurQualité = valeurProduiteBrute / 2;
                iterations++;
                return valeurQualité;
            } else {
                uint valeurInvestissable = 0;

                if (complexitéAccidentelleActuelle > valeurProduiteBrute) {
                    valeurInvestissable = valeurProduiteBrute;
                } else {
                    valeurInvestissable = valeurProduiteBrute - complexitéAccidentelleActuelle;
                }

                decimal minNouvValeurEntropie;

                if (complexitéAccidentelleActuelle < valeurProduiteBrute) {
                    minNouvValeurEntropie = Convert.ToDecimal(scoreProduitActuel + complexitéAccidentelleActuelle + 2 * valeurProduiteBrute - 4 * ((valeurProduiteBrute/2) + complexitéAccidentelleActuelle)) / coutDUnDé;
                } else {
                    minNouvValeurEntropie = Convert.ToDecimal((scoreProduitActuel + complexitéAccidentelleActuelle - 2 * valeurProduiteBrute)) / coutDUnDé;
                }

                decimal maxNouvValeurEntropie = Convert.ToDecimal((scoreProduitActuel + 2 * valeurProduiteBrute + complexitéAccidentelleActuelle)) / coutDUnDé;

                valeurQualité = meilleurChoixQualite(maxNouvValeurEntropie, minNouvValeurEntropie, valeurInvestissable, scoreProduitActuel, valeurProduiteBrute, complexitéAccidentelleActuelle, coutDUnDé);

                iterations++;

                return valeurQualité;
            }
        }

        public uint meilleurChoixQualite(decimal maxNouvValeurEntropie, decimal minNouvValeurEntropie, uint valeurInvestissable, uint scoreProduitActuel, uint valeurProduiteBrute, uint complexitéAccidentelleActuelle, uint coutDUnDé) {

            bool valide = true;
            if (Math.Floor(maxNouvValeurEntropie) > Math.Floor(minNouvValeurEntropie)) {
                decimal nouvValeurEntropie = minNouvValeurEntropie;
                for (uint i = valeurInvestissable; i > 0; i--){
                    if (valeurProduiteBrute - i + complexitéAccidentelleActuelle >= i && valide == false){
                        return complexitéAccidentelleActuelle + valeurInvestissable / 2;
                    }
                    if (Math.Floor(maxNouvValeurEntropie) < nouvValeurEntropie && valeurProduiteBrute - i + complexitéAccidentelleActuelle >= i) {
                        return (i+1);
                    } else {
                        nouvValeurEntropie = Convert.ToDecimal((scoreProduitActuel + 2 * valeurProduiteBrute - 4 * i + complexitéAccidentelleActuelle)) / coutDUnDé;
                    }
                    if (valeurProduiteBrute - i + complexitéAccidentelleActuelle < i){
                        valide = false;
                    }
                }
                if (complexitéAccidentelleActuelle > valeurProduiteBrute) {
                    return 0;
                } else {
                    return complexitéAccidentelleActuelle + valeurInvestissable / 2;
                } 
            } else {
                if (complexitéAccidentelleActuelle > valeurProduiteBrute) {
                    return 0;
                } else {
                    return complexitéAccidentelleActuelle + valeurInvestissable / 2;
                } 
            }
        }

        /// <inheritdoc />
        public IStratégieQualité Fork() => new StratégieClermontGeoffrey();
    }
}

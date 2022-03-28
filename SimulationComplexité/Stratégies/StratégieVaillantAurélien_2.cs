using SimulationComplexité.Notation;
using SimulationComplexité.Simulation.Stratégie;
using SimulationComplexité.Stratégies.Prédéfinies;

namespace SimulationComplexité.Stratégies
{
    internal class StratégieVaillantAurélien_2 : StratégieStateless
    {
        /// <inheritdoc />
        public override uint MontantInvestiEnQualité(
            uint valeurProduiteBrute,
            uint complexitéAccidentelleActuelle,
            uint scoreProduitActuel,
            ushort coûtDUnDé)
        {

            double valeurAMettreEnQualité = 0;

            // Calcul en stratégie prudente
            valeurAMettreEnQualité = (complexitéAccidentelleActuelle + valeurProduiteBrute) / 2;

            // Etalonnage des limites
            var ret1 = complexitéAccidentelleActuelle == 0 ? 1 : (complexitéAccidentelleActuelle / 10) == 0 ? 1 : complexitéAccidentelleActuelle / 10;

            // Loi normale : le maximum de la fonction f est atteint en μ et vaut
            var ret2 = 1 / (ret1 * Math.Sqrt((2 * Math.PI)));

            // Coefficient pour diminuer légèrement l'investissement en qualité
            valeurAMettreEnQualité -= ret2;

            // Sécurité de limite basse
            if (valeurAMettreEnQualité > valeurProduiteBrute)
            {
                valeurAMettreEnQualité = valeurProduiteBrute;
            }

            // Valeur en investissement en qualité
            return (uint) valeurAMettreEnQualité;
        }



        /// <inheritdoc />
        public IStratégieQualité Fork() => new StratégieVaillantAurélien_1();
    }
}

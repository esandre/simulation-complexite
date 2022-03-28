using SimulationComplexité.Notation;
using SimulationComplexité.Simulation.Stratégie;
using SimulationComplexité.Stratégies.Prédéfinies;

namespace SimulationComplexité.Stratégies
{
    internal class StratégieVaillantAurélien_1 : StratégieStateless
    {
        /// <inheritdoc />
        public override uint MontantInvestiEnQualité(
            uint valeurProduiteBrute,
            uint complexitéAccidentelleActuelle,
            uint scoreProduitActuel,
            ushort coûtDUnDé)
        {

            uint valeurAMettreEnQualité = 0;
 



            // Stratégie prudente avec régression de l'investissement en qualité
            valeurAMettreEnQualité = (complexitéAccidentelleActuelle + valeurProduiteBrute) / 2;

            valeurAMettreEnQualité -= 1;

            valeurAMettreEnQualité = valeurAMettreEnQualité < 0 ? 0 : valeurAMettreEnQualité;
  
            if (valeurProduiteBrute < valeurAMettreEnQualité)
            {
                valeurAMettreEnQualité = valeurProduiteBrute;
            }

            return valeurAMettreEnQualité;
        }



        /// <inheritdoc />
        public IStratégieQualité Fork() => new StratégieVaillantAurélien_1();
    }
}

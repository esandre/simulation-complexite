using SimulationComplexité.Simulation.Stratégie;

namespace SimulationComplexité.Stratégies
{
    internal class StratégieAdrienVaucard : IStratégieQualité
    {
        /// <inheritdoc />
        public uint MontantInvestiEnQualité(uint valeurProduiteBrute, uint complexitéAccidentelleActuelle, uint scoreProduitActuel, ushort coutDUnDé)
        {
            uint investissementQualité = 0;
            uint entropie = (scoreProduitActuel + complexitéAccidentelleActuelle) / coutDUnDé;
            
            if (complexitéAccidentelleActuelle <= valeurProduiteBrute)
            {
                if (complexitéAccidentelleActuelle > scoreProduitActuel)
                {
                    investissementQualité = Convert.ToUInt32(Math.Round(complexitéAccidentelleActuelle * 0.6, MidpointRounding.AwayFromZero) );
                    return investissementQualité;
                }
                else
                {
                    investissementQualité = complexitéAccidentelleActuelle / 2;
                    return investissementQualité;
                }
            }
            else
            {
                if (valeurProduiteBrute > 1)
                {
                    investissementQualité = valeurProduiteBrute - 2;
                }
                else
                {
                    investissementQualité = valeurProduiteBrute;
                }
                
                return investissementQualité;
            }
        }

        /// <inheritdoc />
        public IStratégieQualité Fork() => new StratégieAdrienVaucard();
    }
}

using SimulationComplexité.Simulation.Stratégie;

namespace SimulationComplexité.Stratégies
{
    internal class StratégieBigeardRobin : IStratégieQualité
    {
        /// <inheritdoc />
        public uint MontantInvestiEnQualité(
            uint valeurProduiteBrute, 
            uint complexitéAccidentelleActuelle,
            uint scoreProduitActuel, 
            ushort coutDUnDé)
        {
            if (complexitéAccidentelleActuelle > valeurProduiteBrute && valeurProduiteBrute > 1) return valeurProduiteBrute - 2; // Good
            // if (complexitéAccidentelleActuelle > valeurProduiteBrute && valeurProduiteBrute > 1) return valeurProduiteBrute - valeurProduiteBrute / 2;
            if (complexitéAccidentelleActuelle > valeurProduiteBrute) return 0;
            return complexitéAccidentelleActuelle / 2 + (valeurProduiteBrute - complexitéAccidentelleActuelle) / 2;
        }

        /// <inheritdoc /> TEST
        /*public uint MontantInvestiEnQualité(uint valeurProduiteBrute, uint complexitéAccidentelleActuelle, uint scoreProduitActuel, ushort coutDUnDé)
        {
            double val = (double) valeurProduiteBrute;
            bool test = val % 2.0 == 0.0;
            Console.WriteLine(test);
            Console.WriteLine(complexitéAccidentelleActuelle);
            Console.WriteLine(valeurProduiteBrute);
            if (test)
            {
                uint v = valeurProduiteBrute / 2;
                Console.WriteLine(v);
                return v;
            }
            
            uint t = complexitéAccidentelleActuelle + valeurProduiteBrute / 2;
            if (t < 0 || t > valeurProduiteBrute)
            {
                t = valeurProduiteBrute / 2;
            }
            Console.WriteLine(t);
            return t;
        }*/

        /// <inheritdoc />
        public IStratégieQualité Fork() => new VotreStratégie();
    }
}

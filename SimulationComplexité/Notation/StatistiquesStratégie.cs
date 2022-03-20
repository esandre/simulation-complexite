using SimulationComplexité.Simulation.Stratégie;

namespace SimulationComplexité.Notation
{
    internal class StatistiquesStratégie : IComparable<StatistiquesStratégie>
    {
        private readonly uint _nombreParties;

        public StatistiquesStratégie(
            IStratégieQualité stratégie,
            uint nombreParties,
            ushort nombreItérationsMoyen, 
            uint complexitéMoyenne, 
            uint valeurMoyenne)
        {
            _nombreParties = nombreParties;
            Stratégie = stratégie;
            NombreItérationsMoyen = nombreItérationsMoyen;
            ComplexitéMoyenne = complexitéMoyenne;
            ValeurMoyenne = valeurMoyenne;
        }

        private const double ToléranceValeurMoyenne = 0.05;
        private const double ToléranceScoreMoyen = 0.05;

        public IStratégieQualité Stratégie { get; }
        private ushort NombreItérationsMoyen { get; }
        private uint ComplexitéMoyenne { get; }
        private uint ValeurMoyenne { get; }

        /// <inheritdoc />
        public int CompareTo(StatistiquesStratégie? other)
        {
            if (other is null) return 1;

            if (ValeurMoyenne != other.ValeurMoyenne)
            {
                var différenceValeur = SubstractUint(ValeurMoyenne, other.ValeurMoyenne);

                var moyenne = ((double) ValeurMoyenne + other.ValeurMoyenne) / 2;
                if (Math.Abs(différenceValeur / moyenne) > ToléranceScoreMoyen) return différenceValeur;
            }

            var valeurMoyenneParItération = (double) ValeurMoyenne / NombreItérationsMoyen;
            var valeurMoyenneParItérationOther = (double) other.ValeurMoyenne / other.NombreItérationsMoyen;
            var différence = valeurMoyenneParItération - valeurMoyenneParItérationOther;

            if (différence > ToléranceValeurMoyenne) return 1;
            if (différence < -ToléranceValeurMoyenne) return -1;

            return SubstractUint(ComplexitéMoyenne, other.ComplexitéMoyenne);
        }

        private static int SubstractUint(uint a, uint b) => (int)a - (int) b;

        public void Print()
        {
            Console.WriteLine(
                $"Sur {_nombreParties} parties la stratégie {Stratégie} a donné un score moyen de {ValeurMoyenne}(+/- {ToléranceScoreMoyen:P}), " +
                $"une complexité moyenne de {ComplexitéMoyenne} sur {NombreItérationsMoyen} itérations en moyenne " +
                $"soit {(double)ValeurMoyenne / NombreItérationsMoyen:F}(+/- {ToléranceValeurMoyenne:P}) valeur/itération.");

            Console.WriteLine();
        }
    }
}

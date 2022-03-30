using SimulationComplexité.Notation;

namespace SimulationComplexité.Sortie
{
    internal static class PrintStatistiquesExtension
    {
        private static readonly IComparer<StatistiquesStratégie> ComparaisonSecondeChance =
            new ComparaisonParValeurMoyenneParItération(
                StatistiquesStratégie.ToléranceValeurMoyenneParItération,
                new ComparaisonParComplexitéFinale()
            );

        private static readonly IComparer<StatistiquesStratégie> ComparaisonParValeurBrute =
            new ComparaisonParValeurBrute(
                StatistiquesStratégie.ToléranceValeurBrute,
                ComparaisonSecondeChance
            );

        private static readonly IComparer<StatistiquesStratégie> ComparaisonParMédiane =
            new ComparaisonParValeurMédiane(
                StatistiquesStratégie.ToléranceValeurMédiane,
                ComparaisonSecondeChance
            );

        public static void PrintStatistiquesParMédiane(this IEnumerable<StatistiquesStratégie> statistiques)
        {
            foreach (var statistiquesStratégie in statistiques.OrderBy(e => e, ComparaisonParMédiane))
                statistiquesStratégie.Print();
        }

        public static void PrintStatistiquesParValeurBrute(this IEnumerable<StatistiquesStratégie> statistiques)
        {
            foreach (var statistiquesStratégie in statistiques.OrderBy(e => e, ComparaisonParValeurBrute))
            {
                {
                    if (statistiquesStratégie.Stratégie is IStratégieÉtalon étalon)
                        Console.WriteLine($"-----{étalon.Note}/20-----");
                }

                statistiquesStratégie.Print();

                {
                    if (statistiquesStratégie.Stratégie is IStratégieÉtalon étalon)
                        Console.WriteLine($"-----{étalon.Note+1}/20-----");
                }
            }
        }
    }
}

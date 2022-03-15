using SimulationComplexité.Notation;
using SimulationComplexité.Stratégies;
using SimulationComplexité.Stratégies.Prédéfinies;

namespace SimulationComplexité.Sortie
{
    internal static class PrintStatistiquesExtension
    {
        public static void PrintStatistiques(this IOrderedEnumerable<StatistiquesStratégie> statistiques)
        {
            IStratégieÉtalon meilleurÉtalon = new StratégieDavidGoodenough();
            var stratégieCustomClassée = false;

            foreach (var statistiquesStratégie in statistiques)
            {
                var stratégie = statistiquesStratégie.Stratégie;
                if (!stratégieCustomClassée && stratégie is IStratégieÉtalon étalon) meilleurÉtalon = étalon;

                statistiquesStratégie.Print();

                if (stratégie is StratégieClermontGeoffrey) stratégieCustomClassée = true;
            }

            Console.WriteLine(
                $"Votre stratégie a obtenu la note de {meilleurÉtalon.Note + 1}/20 pour s'être placée au-dessus de {meilleurÉtalon}");
        }
    }
}

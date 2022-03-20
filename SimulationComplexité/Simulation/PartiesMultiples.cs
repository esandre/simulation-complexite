using System.Collections.Concurrent;
using System.Collections.Immutable;
using SimulationComplexité.Notation;
using SimulationComplexité.Simulation.Stratégie;
using SimulationComplexité.Sortie;

namespace SimulationComplexité.Simulation
{
    internal class PartiesMultiples
    {
        private readonly ISortiePartie _sortie;
        private readonly ParamètresPartie _paramètresGénéraux;
        private readonly IImmutableDictionary<IStratégieQualité, ConcurrentBag<RésultatPartie>> _historiqueParties;

        public PartiesMultiples(
            ISortiePartie sortie, 
            ParamètresPartie paramètresGénéraux, 
            IEnumerable<IStratégieQualité> stratégies)
        {
            _sortie = sortie;
            _paramètresGénéraux = paramètresGénéraux;
            _historiqueParties = stratégies.ToImmutableDictionary(stratégie => stratégie, _ => new ConcurrentBag<RésultatPartie>());
        }

        public void Jouer(ushort nombreParties)
        {
            Parallel.ForEach(_historiqueParties.Keys,
                stratégieQualité =>
                {
                    Parallel.For(0, nombreParties,
                        _ =>
                        {
                            var stratégie = stratégieQualité.Fork();
                            var partie = new Partie(_sortie, new Dés6Faces(), _paramètresGénéraux,
                                stratégie);
                            _historiqueParties[stratégieQualité].Add(partie.Jouer());
                        });
                });
        }

        public IOrderedEnumerable<StatistiquesStratégie> CalculerStatistiques() => 
            _historiqueParties
            .Select(kv =>
            {
                var (stratégie, historique) = kv;

                var moyenneValeur =
                    Convert.ToUInt32(historique.Sum(partie => partie.ValeurProduite) / historique.Count);
                var moyenneComplexité =
                    Convert.ToUInt32(historique.Sum(partie => partie.ComplexitéAccidentelle) / historique.Count);
                var moyenneItérations =
                    Convert.ToUInt16(historique.Sum(partie => partie.ItérationFinale) / historique.Count);

                return new StatistiquesStratégie(stratégie, (uint) historique.Count, moyenneItérations, moyenneComplexité,
                    moyenneValeur);
            })
            .AsParallel()
            .ToArray()
            .OrderBy(statistiques => statistiques);
    }
}

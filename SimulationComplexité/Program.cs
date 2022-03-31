using System.Reflection;
using SimulationComplexité.Simulation;
using SimulationComplexité.Simulation.Stratégie;
using SimulationComplexité.Sortie;

/*
 * README
 *
 * Vous devez produire l'implémentation la plus performante de l'algo
 * Tous les coups sont permis. Rétro-ingénierie, calculs de renard, algos génétiques, etc.
 * Pour noter, je prends votre algorithme qui implémente IStratégieQualité et je le compare aux autres.
 * J'utilise mon implémentation de départ.
 * Merci de Renommer votre implémentation sous la forme StratégieNomPrénom.
 *
 * Battre tous mes algorithmes octroie un 11 d'office.
 * Le meilleur algo de toute la classe sera couronné d'un 20, le second d'un 19, etc.
 *
 * Si votre PC est une patate, vous pouvez diminuer le nombre de parties. J'évaluerai de mon côté sur 10k parties.
 * Vous pouvez passer en Verbose, mais attention, avec plus de 10 parties c'est long à lire.
 */

const int coûtDUnDé = 180;
const int nombreDés = 12;
const int nombreParties = 10000;
const bool verbose = false;

var stratégiesQualité = Assembly.GetAssembly(typeof(IStratégieQualité))!
    .GetTypes()
    .Where(t => t.GetInterfaces().Contains(typeof(IStratégieQualité)))
    .Where(t => t.GetConstructor(Type.EmptyTypes) != null)
    .Select(Activator.CreateInstance)
    .Cast<IStratégieQualité>();

// ReSharper disable once ConditionIsAlwaysTrueOrFalse
// ReSharper disable once HeuristicUnreachableCode
ISortiePartie sortieParties = verbose ? new SortieConsole() : new SortieIgnorée();
var paramètresGénéraux = new ParamètresPartie(nombreDés, 0, 0, coûtDUnDé);

var parties = new PartiesMultiples(sortieParties, paramètresGénéraux, stratégiesQualité);
parties.Jouer(nombreParties);
var statistiques = parties.CalculerStatistiques().ToArray();
statistiques.PrintStatistiquesParValeurBrute();
using SimulationComplexité.Simulation;
using SimulationComplexité.Simulation.Stratégie;
using SimulationComplexité.Sortie;
using SimulationComplexité.Stratégies;
using SimulationComplexité.Stratégies.Prédéfinies;

#pragma warning disable CS0162

const int coûtDUnDé = 18;
const int nombreDés = 12;
const int nombreParties = 10000;
const bool verbose = false;

var stratégiesQualité = new IStratégieQualité[]
{
    new StratégieDavidGoodenough(),
    new StratégieQuiVaChaptiVaLoin(),
    new StratégiePrudente(),
    new VotreStratégie()
};

// ReSharper disable once ConditionIsAlwaysTrueOrFalse
// ReSharper disable once HeuristicUnreachableCode
ISortiePartie sortieParties = verbose ? new SortieConsole() : new SortieIgnorée();
var paramètresGénéraux = new ParamètresPartie(nombreDés, 0, 0, coûtDUnDé);

var parties = new PartiesMultiples(sortieParties, paramètresGénéraux, stratégiesQualité);
parties.Jouer(nombreParties);
var statistiques = parties.CalculerStatistiques().ToArray();
statistiques.PrintStatistiquesParValeurBrute();
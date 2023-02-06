using SimulationComplexité.Simulation.Stratégie;

namespace SimulationComplexité.Notation;

internal class StatistiquesStratégie
{
    private readonly uint _nombreParties;

    public StatistiquesStratégie(
        IStratégieQualité stratégie,
        uint nombreParties,
        ushort nombreItérationsMoyen, 
        uint complexitéMoyenne, 
        uint valeurMoyenne,
        uint valeurMédiane)
    {
        _nombreParties = nombreParties;
        Stratégie = stratégie;
        NombreItérationsMoyen = nombreItérationsMoyen;
        ComplexitéMoyenne = complexitéMoyenne;
        ValeurMoyenne = valeurMoyenne;
        ValeurMédiane = valeurMédiane;
    }

    public const ushort ToléranceValeurMoyenneParItération = 5;
    public const ushort ToléranceValeurBrute = 5;
    public const ushort ToléranceValeurMédiane = 5;

    public IStratégieQualité Stratégie { get; }
    public ushort NombreItérationsMoyen { get; }
    public uint ComplexitéMoyenne { get; }
    public uint ValeurMoyenne { get; }
    public uint ValeurMédiane { get; }

    public void Print()
    {
        Console.WriteLine(
            $"Sur {_nombreParties} parties la stratégie {Stratégie} " +
            $"a donné un score moyen de {ValeurMoyenne}(~{ToléranceValeurMoyenneParItération / 10.0}%), " +
            $"une complexité moyenne de {ComplexitéMoyenne} sur {NombreItérationsMoyen} itérations en moyenne " +
            $"et une valeur médiane de {ValeurMédiane}(~{ToléranceValeurMédiane/10.0}%) " +
            $"soit {(double)ValeurMoyenne / NombreItérationsMoyen:F}(~{ToléranceValeurBrute / 10.0}%) valeur/itération.");

        Console.WriteLine();
    }
}
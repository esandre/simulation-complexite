namespace SimulationComplexité.Sortie;

internal interface ISortiePartie
{
    void Write(string str);
    void WriteLine();
}

internal static class SortiePartieExtensions 
{
    public static void WriteLine(this ISortiePartie sortie, string str)
    {
        sortie.Write(str);
        sortie.WriteLine();
    }
}
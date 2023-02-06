namespace SimulationComplexité.Sortie;

internal class SortieConsole : ISortiePartie
{
    /// <inheritdoc />
    public void Write(string str) => Console.Write(str);

    /// <inheritdoc />
    public void WriteLine() => Console.WriteLine();
}
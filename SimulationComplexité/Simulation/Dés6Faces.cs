namespace SimulationComplexité.Simulation;

internal class Dés6Faces
{
    private static readonly Random AppWideRandom = new ();
    private readonly Random _diceWideRandom = new (AppWideRandom.Next());
        
    public int Lancer(ushort nombreDés) => 
        Enumerable.Range(0, nombreDés)
            .Select(_ => _diceWideRandom.Next(1, 6))
            .Sum();
}
namespace SimulationComplexité.Notation;

internal class ComparaisonParValeurBrute : IComparer<StatistiquesStratégie>
{
    private readonly double _tolérance;
    private readonly IComparer<StatistiquesStratégie>? _secondChoix;

    public ComparaisonParValeurBrute(ushort tolérancePourMille, 
        IComparer<StatistiquesStratégie>? secondChoix = default)
    {
        _tolérance = tolérancePourMille / 1000.0;
        _secondChoix = secondChoix;
    }

    public int Compare(StatistiquesStratégie? x, StatistiquesStratégie? y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (ReferenceEquals(null, y)) return 1;
        if (ReferenceEquals(null, x)) return -1;

        var comparaisonParValeur = SubstractUint(x.ValeurMoyenne, y.ValeurMoyenne);
        var marge = x.ValeurMoyenne * _tolérance;

        if (Math.Abs(comparaisonParValeur) <= marge) 
            return _secondChoix?.Compare(x, y) ?? 0;

        return comparaisonParValeur;
    }

    private static int SubstractUint(uint a, uint b) => (int)a - (int)b;
}
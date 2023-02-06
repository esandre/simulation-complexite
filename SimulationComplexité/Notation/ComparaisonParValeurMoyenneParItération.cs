namespace SimulationComplexité.Notation;

internal class ComparaisonParValeurMoyenneParItération : IComparer<StatistiquesStratégie>
{
    private readonly double _tolérance;
    private readonly IComparer<StatistiquesStratégie>? _secondChoix;

    public ComparaisonParValeurMoyenneParItération(ushort tolérancePourMille, 
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

        var comparaisonParValeur = x.ValeurMoyenneParItération() - y.ValeurMoyenneParItération();
        var marge = x.ValeurMoyenneParItération() * _tolérance;

        if (Math.Abs(comparaisonParValeur) <= marge) 
            return _secondChoix?.Compare(x, y) ?? 0;

        return comparaisonParValeur > 0 ? 1 : - 1;
    }
}

internal static class ValeurMoyenneParItérationExtensions
{
    public static double ValeurMoyenneParItération(this StatistiquesStratégie statistiques)
        // ReSharper disable once PossibleLossOfFraction
        => statistiques.ValeurMoyenne / statistiques.NombreItérationsMoyen;
}
namespace SimulationComplexité.Notation
{
    internal class ComparaisonParComplexitéFinale : IComparer<StatistiquesStratégie>
    {
        public int Compare(StatistiquesStratégie? x, StatistiquesStratégie? y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (ReferenceEquals(null, y)) return 1;
            if (ReferenceEquals(null, x)) return -1;

            return x.ComplexitéMoyenne.CompareTo(y.ComplexitéMoyenne);
        }
    }
}

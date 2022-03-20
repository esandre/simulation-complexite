using SimulationComplexité.Simulation.Stratégie;
using SimulationComplexité.Sortie;

namespace SimulationComplexité.Simulation
{
    internal class Partie
    {
        private readonly ISortiePartie _sortie;
        private readonly Dés6Faces _simulateurLancer;
        private readonly ParamètresPartie _paramètres;
        private readonly IStratégieQualité _stratégieQualité;

        public Partie(ISortiePartie sortie, 
            Dés6Faces simulateurLancer, 
            ParamètresPartie paramètres, 
            IStratégieQualité stratégieQualité)
        {
            _sortie = sortie;
            _simulateurLancer = simulateurLancer;
            _paramètres = paramètres;
            _stratégieQualité = new ProtectionStratégieQualité(stratégieQualité);
        }

        public RésultatPartie Jouer()
        {
            uint itérationActuelle = 1;
            var désEntropie = _paramètres.NombreDésEntropieDépart;
            var désVélocité = _paramètres.NombreDésVélocitéDépart;
            var nombreTotalDés = désEntropie + désVélocité;

            var historiqueValeurProduite = new Stack<uint>();
            var complexitéAccidentelle = _paramètres.ComplexitéAccidentelleDépart;

            while ((historiqueValeurProduite.Count < 3 || historiqueValeurProduite.Take(3).Sum() > 0) && désVélocité > 0)
            {
                _sortie.WriteLine($"Itération {itérationActuelle++}");
                _sortie.WriteLine($"{désVélocité} dés de vélocité. {désEntropie} dés d'entropie.");

                var tirageEntropie = _simulateurLancer.Lancer(désEntropie);
                var tirageVélocité = _simulateurLancer.Lancer(désVélocité);
                var valeurProduiteBrute = tirageVélocité - tirageEntropie;

                if(valeurProduiteBrute >= 0)
                {
                    _sortie.WriteLine($"{tirageVélocité} - {tirageEntropie} = {valeurProduiteBrute} valeur produite brute");

                    var investissementQualité = _stratégieQualité.MontantInvestiEnQualité(
                        Convert.ToUInt32(valeurProduiteBrute), 
                        complexitéAccidentelle,
                        historiqueValeurProduite.Sum(),
                        _paramètres.CoûtDUnDé);

                    var investissementProduit = valeurProduiteBrute - investissementQualité;
                    _sortie.WriteLine($"{investissementQualité} investi en qualité. {investissementProduit} investis dans le produit.");
                    
                    historiqueValeurProduite.Push(Convert.ToUInt32(investissementProduit));

                    var différenceComplexitéAdditionnelle = investissementProduit - investissementQualité;
                    var complexitéPotentielle = complexitéAccidentelle + différenceComplexitéAdditionnelle;
                    
                    complexitéAccidentelle = Convert.ToUInt32(complexitéPotentielle);
                }
                else
                {
                    _sortie.WriteLine($"{tirageVélocité} - {tirageEntropie} = {-valeurProduiteBrute} complexité accidentelle ajoutée");
                    complexitéAccidentelle += Convert.ToUInt32(-valeurProduiteBrute);

                    historiqueValeurProduite.Push(0);
                }

                var valeurProduiteTour = historiqueValeurProduite.Sum();

                _sortie.WriteLine(
                    $"La valeur produite depuis le début est de {valeurProduiteTour} et la complexité accidentelle de {complexitéAccidentelle}.");

                _sortie.WriteLine($"La complexité totale est de {valeurProduiteTour + complexitéAccidentelle}.");

                désEntropie = Convert.ToUInt16(Math.Min(nombreTotalDés, (complexitéAccidentelle + valeurProduiteTour) / _paramètres.CoûtDUnDé));
                désVélocité = Convert.ToUInt16(nombreTotalDés - désEntropie);

                _sortie.WriteLine();
            }

            var valeurProduite = historiqueValeurProduite.Sum();

            _sortie.WriteLine($"Votre projet est mort après avoir produit {valeurProduite} valeur " +
                                    $"et {complexitéAccidentelle} complexité accidentelle en {itérationActuelle} itérations.");

            _sortie.WriteLine();
            _sortie.WriteLine();

            return new RésultatPartie(complexitéAccidentelle, valeurProduite, itérationActuelle);
        }
    }
}

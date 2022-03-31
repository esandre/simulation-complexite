using SimulationComplexité.Simulation.Stratégie;

namespace SimulationComplexité.Stratégies;

internal class StratégieGuillaumeGouy : IStratégieQualité
{
    private int _iteration;

    // ce booleen permet de  ralentir la courbe de la croissance de la comlexité accidentelle
    // Son usage est commenté car il nuit aux perfs ...
    private bool _perdreEnQualite;
    private int _sommeInvestissementProduit;
    private int _sommeInvestissementQualite;
    private int projetMort = 55;
    private bool refactoEfficace = true;
    private int seuilComplexiteAdmis = 9;

    /// <inheritdoc />
    public uint MontantInvestiEnQualité(uint valeurProduiteBrute, uint complexitéAccidentelleActuelle,
        uint scoreProduitActuel, ushort coutDUnDé)
    {
        /*if (_iteration == 0)
        {
            _perdreEnQualite = false;
            
            
        }*/

        _iteration++;
        var investissementQualite =
            soustractionInvestissementProduitInvestQualitéNull(valeurProduiteBrute, _iteration,
                complexitéAccidentelleActuelle);

        /*if (valeurProduiteBrute > 2 && refactoEfficace == true)
        {
            investissementQualite =
                this.admettreCroissanceComplexiteAccidentellePhaseAscendate(investissementQualite/*,ref _perdreEnQualite);    
        }

        if (complexitéAccidentelleActuelle > seuilComplexiteAdmis && valeurProduiteBrute > 2 && _iteration < projetMort)
        {
           
            investissementQualite = this.refacto(complexitéAccidentelleActuelle , valeurProduiteBrute , ref refactoEfficace);
        }
        */

        return investissementQualite;
    }

    /// <inheritdoc />
    public IStratégieQualité Fork()
    {
        return new StratégieGuillaumeGouy();
    }

    public uint soustractionInvestissementProduitInvestQualitéNull(uint valeurProduiteBrute, int iterationActuelle,
        uint complexitéAccidentelleActuelle)
    {
        double investissemntQualite = 0;
        double invesissementProduit = 0;

        // maniere d investir --> 
        var valeurProduiteParDeux = (float)valeurProduiteBrute / 2;
        var modulo = valeurProduiteParDeux % 2;

        if (valeurProduiteParDeux % 2 == 0)
        {
            investissemntQualite = Math.Truncate(valeurProduiteParDeux);
            invesissementProduit = Math.Round(valeurProduiteParDeux);

            _sommeInvestissementProduit = _sommeInvestissementProduit + (int)invesissementProduit;
            _sommeInvestissementQualite = _sommeInvestissementQualite + (int)investissemntQualite;
        }

        if (valeurProduiteParDeux % 2 != 0 && _iteration == 1)
        {
            investissemntQualite = Math.Truncate(valeurProduiteParDeux);
            // observer comporterment lorque x = .5
            invesissementProduit = Math.Round(valeurProduiteParDeux, MidpointRounding.AwayFromZero);

            _sommeInvestissementProduit = _sommeInvestissementProduit + (int)invesissementProduit;
            _sommeInvestissementQualite = _sommeInvestissementQualite + (int)investissemntQualite;
        }


        if (valeurProduiteParDeux % 2 != 0 && _iteration > 1)
        {
            if (_sommeInvestissementProduit > _sommeInvestissementQualite && complexitéAccidentelleActuelle > 0)
            {
                invesissementProduit = Math.Truncate(valeurProduiteParDeux);
                investissemntQualite = Math.Round(valeurProduiteParDeux, MidpointRounding.AwayFromZero);


                _sommeInvestissementProduit = _sommeInvestissementProduit + (int)invesissementProduit;
                _sommeInvestissementQualite = _sommeInvestissementQualite + (int)investissemntQualite;
            }
            else if (_sommeInvestissementQualite > _sommeInvestissementProduit)
            {
                investissemntQualite = Math.Truncate(valeurProduiteParDeux);
                invesissementProduit = Math.Round(valeurProduiteParDeux, MidpointRounding.AwayFromZero);

                _sommeInvestissementProduit = _sommeInvestissementProduit + (int)invesissementProduit;
                _sommeInvestissementQualite = _sommeInvestissementQualite + (int)investissemntQualite;
            }

            else if (_sommeInvestissementQualite == _sommeInvestissementProduit)
            {
                investissemntQualite = Math.Truncate(valeurProduiteParDeux);
                invesissementProduit = Math.Round(valeurProduiteParDeux, MidpointRounding.AwayFromZero);

                _sommeInvestissementProduit = _sommeInvestissementProduit + (int)invesissementProduit;
                _sommeInvestissementQualite = _sommeInvestissementQualite + (int)investissemntQualite;
            }
        }

        return Convert.ToUInt32(investissemntQualite);
    }

    public uint admettreCroissanceComplexiteAccidentellePhaseAscendate(
        uint investissementQualité /*,ref bool unSurDeux*/)
    {
        // DETAIL RAISONNEMENT :
        // Cet algo a pour but de stimuler l 'investissement produit en relativisant l'investissement qualité

        /*if (unSurDeux)
        {
            investissementQualité--;
            unSurDeux = false;
        }
        else if (!unSurDeux)
        {
           
            unSurDeux = true;
        }*/


        investissementQualité--;
        return investissementQualité;
    }

    public uint refacto(uint complexiteAccidentelleT, uint valeurProduiteBrute, ref bool refactoEfficace)
    {
        refactoEfficace = false;
        uint investissementQualite = 0;
        if (valeurProduiteBrute > complexiteAccidentelleT)
            investissementQualite = complexiteAccidentelleT;
        else if (valeurProduiteBrute == complexiteAccidentelleT)
            investissementQualite = complexiteAccidentelleT;
        else if (complexiteAccidentelleT > valeurProduiteBrute) investissementQualite = valeurProduiteBrute;

        var differenceContinuerRefactoOuPas = complexiteAccidentelleT - investissementQualite;

        if (differenceContinuerRefactoOuPas < 4) refactoEfficace = true;
        return investissementQualite;
    }
}
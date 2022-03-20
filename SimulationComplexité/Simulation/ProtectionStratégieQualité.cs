using SimulationComplexité.Simulation.Stratégie;

namespace SimulationComplexité.Simulation
{
    internal class ProtectionStratégieQualité : IStratégieQualité
    {
        private readonly IStratégieQualité _aProtéger;

        public ProtectionStratégieQualité(IStratégieQualité aProtéger)
        {
            _aProtéger = aProtéger;
        }

        /// <inheritdoc />
        public uint MontantInvestiEnQualité(
            uint valeurProduiteBrute, 
            uint complexitéAccidentelleActuelle, 
            uint scoreProduitActuel,
            ushort coûtDUnDé)
        {
            var montantRenvoyé = _aProtéger.MontantInvestiEnQualité(
                valeurProduiteBrute, 
                complexitéAccidentelleActuelle, 
                scoreProduitActuel, 
                coûtDUnDé);

            if (montantRenvoyé > valeurProduiteBrute)
                throw new InvalidOperationException($"Vous avez tenté d'investir {montantRenvoyé} en qualité, " +
                                                    $"alors que vous ne possédez que {valeurProduiteBrute} point à allouer.");

            var complexitéAccidentelleProduite = (long) valeurProduiteBrute - montantRenvoyé;
            var complexitéAccidentelleFinale = complexitéAccidentelleProduite + complexitéAccidentelleActuelle;
            if(complexitéAccidentelleFinale < 0)
                throw new InvalidOperationException($"Si vous investissez {montantRenvoyé} en qualité comme prévu, " +
                                                    $"la complexité accidentelle deviendrait négative. " +
                                                    $"Détail du calcul {valeurProduiteBrute} - {montantRenvoyé} + " +
                                                    $"{complexitéAccidentelleActuelle} = {complexitéAccidentelleFinale}");

            return montantRenvoyé;
        }

        /// <inheritdoc />
        public IStratégieQualité Fork() => new ProtectionStratégieQualité(_aProtéger.Fork());
    }
}

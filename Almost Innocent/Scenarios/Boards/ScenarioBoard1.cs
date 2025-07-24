using Almost_Innocent.Cards;

using static Almost_Innocent.Cards.CrimeCard;
using static Almost_Innocent.Cards.EmptyCard;
using static Almost_Innocent.Cards.EvidenceCard;
using static Almost_Innocent.Cards.PlaceCard;
using static Almost_Innocent.Cards.VictimCard;

namespace Almost_Innocent.Scenarios.Boards
{
    public class ScenarioBoard1 : BaseBoard
    {
        public ScenarioBoard1()
            : base(BuildBoard)
        {
        }

        private static BaseCard[,] BuildBoard
            => new BaseCard[6, 6] // Lignes, Colonnes
				{
							 /* A */		/* B */				/* C */				/* D */			/* E */		/* F */
					/* 1 */{ DONJON,        INCENDIE,           EMPTY,              EMPTY,          POT_DE_VIN, EGLISE },
					/* 2 */{ SAVON,         EMPTY,              SORCIER_MALADROIT,  MAGE_SENSIBLE,  EMPTY,      POTION },
					/* 3 */{ EMPTY,         GRENOUILLE_EPEISTE, ESCROQUERIE,        TAVERNE,        CABANE,     EMPTY },
					/* 4 */{ EMPTY,         MALEDICTION,        MONTRE,             THE_EPICE,      BOUCLIER,   EMPTY },
					/* 5 */{ AGRESSION,     EMPTY,              VEUVE_ASTUCIEUSE,   LAPIN_VIGILANT, EMPTY,      GARDE_BATRACIEN },
					/* 6 */{ PHARE,         TOME,               EMPTY,              EMPTY,          CHANTAGE,   MOULIN }
                };
    }
}


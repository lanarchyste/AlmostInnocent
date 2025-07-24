using Almost_Innocent.Cards;

using static Almost_Innocent.Cards.CrimeCard;
using static Almost_Innocent.Cards.EmptyCard;
using static Almost_Innocent.Cards.EvidenceCard;
using static Almost_Innocent.Cards.PlaceCard;
using static Almost_Innocent.Cards.VictimCard;

namespace Almost_Innocent.Scenarios.Boards
{
    public class ScenarioBoard4() : BaseBoard(BuildBoard)
    {
        private static BaseCard[,] BuildBoard
            => new BaseCard[,] // Lignes, Colonnes
				{
							 /* A */			/* B */			    /* C */				/* D */				/* E */		    /* F */
					/* 1 */{ GARDE_BATRACIEN,   EMPTY,              EGLISE,             VEUVE_ASTUCIEUSE,   POT_DE_VIN,     GRENOUILLE_EPEISTE },
					/* 2 */{ GARDE_BATRACIEN,   TAVERNE,            LAPIN_VIGILANT,     INCENDIE,           EMPTY,          GRENOUILLE_EPEISTE },
					/* 3 */{ MALEDICTION,       MONTRE,             EMPTY,              EMPTY,              AGRESSION,      THE_EPICE },
                    /* 4 */{ TOME,              DONJON,             EMPTY,              EMPTY,              BOUCLIER,       CABANE },
					/* 5 */{ EMPTY,             SORCIER_MALADROIT,  PHARE,              ESCROQUERIE,        MAGE_SENSIBLE,  MOULIN },
                    /* 6 */{ CHANTAGE,          SORCIER_MALADROIT,  SAVON,              POTION,             MAGE_SENSIBLE,  EMPTY }
                };
    }
}


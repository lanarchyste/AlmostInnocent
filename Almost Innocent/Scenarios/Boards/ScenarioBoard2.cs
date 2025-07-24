using Almost_Innocent.Cards;

using static Almost_Innocent.Cards.CrimeCard;
using static Almost_Innocent.Cards.EmptyCard;
using static Almost_Innocent.Cards.EvidenceCard;
using static Almost_Innocent.Cards.PlaceCard;
using static Almost_Innocent.Cards.VictimCard;

namespace Almost_Innocent.Scenarios.Boards
{
    public class ScenarioBoard2() : BaseBoard(BuildBoard)
    {
        private static BaseCard[,] BuildBoard
            => new BaseCard[,] // Lignes, Colonnes
				{
							 /* A */		/* B */				/* C */		/* D */		/* E */				/* F */
					/* 1 */{ EMPTY,         GRENOUILLE_EPEISTE, MOULIN,     EGLISE,     EMPTY,              VEUVE_ASTUCIEUSE },
					/* 2 */{ THE_EPICE,     SAVON,              AGRESSION,  EMPTY,      LAPIN_VIGILANT,     EMPTY },
					/* 3 */{ MALEDICTION,   INCENDIE,           EMPTY,      TAVERNE,    EMPTY,              POTION},
					/* 4 */{ ESCROQUERIE,   EMPTY,              PHARE,      EMPTY,      BOUCLIER,           MONTRE },
					/* 5 */{ EMPTY,         GARDE_BATRACIEN,    EMPTY,      TOME,       CABANE,             DONJON },
                    /* 6 */{ MAGE_SENSIBLE, EMPTY,              CHANTAGE,   POT_DE_VIN, SORCIER_MALADROIT,  EMPTY }
                };
    }
}


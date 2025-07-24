using Almost_Innocent.Cards;

using static Almost_Innocent.Cards.CrimeCard;
using static Almost_Innocent.Cards.EmptyCard;
using static Almost_Innocent.Cards.EvidenceCard;
using static Almost_Innocent.Cards.PlaceCard;
using static Almost_Innocent.Cards.VictimCard;
using static Almost_Innocent.Cards.GuiltyCard;

namespace Almost_Innocent.Scenarios.Boards
{
    public class ScenarioBoard7 : BaseBoard
    {
        public ScenarioBoard7()
            : base(BuildBoard)
        {
        }

        private static BaseCard[,] BuildBoard
            => new BaseCard[6, 6] // Lignes, Colonnes
				{
							 /* A */			/* B */					/* C */					/* D */				/* E */						/* F */
					/* 1 */{ GARDE_BATRACIEN,   MAGE_SENSIBLE,          TAVERNE,                EMPTY,              BOUCLIER,                   MONTRE },
					/* 2 */{ VEUVE_ASTUCIEUSE,  LAPIN_VIGILANT,         SORCIER_MALADROIT,      THE_EPICE,          SAVON,                      POTION },
					/* 3 */{ EMPTY,             GRENOUILLE_EPEISTE,     EGLISE,                 CABANE,             TOME,                       EMPTY },
                    /* 4 */{ EMPTY,             CHANTAGE,               DONJON,                 PHARE,              MAGICIEN_MEFIANT,           EMPTY },
					/* 5 */{ MALEDICTION,       ESCROQUERIE,            POT_DE_VIN,             BARIBAL_BARBARE,    PIRATE_PATATE,              RONGEUR_RUSE },
                    /* 6 */{ AGRESSION,         INCENDIE,               EMPTY,                  MOULIN,             CROCO_AUX_CROCS_CROCHUS,    DRUIDE_DISCRETE }
                };
    }
}


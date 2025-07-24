using Almost_Innocent.Cards;

using static Almost_Innocent.Cards.CrimeCard;
using static Almost_Innocent.Cards.EmptyCard;
using static Almost_Innocent.Cards.EvidenceCard;
using static Almost_Innocent.Cards.GuiltyCard;
using static Almost_Innocent.Cards.PlaceCard;
using static Almost_Innocent.Cards.VictimCard;

namespace Almost_Innocent.Scenarios.Boards
{
    public class ScenarioBoard5 : BaseBoard
    {
        public ScenarioBoard5()
            : base(BuildBoard)
        {
        }

        private static BaseCard[,] BuildBoard
            => new BaseCard[6, 6] // Lignes, Colonnes
				{
							 /* A */			    /* B */             /* C */             /* D */				/* E */             /* F */
					/* 1 */{ CABANE,                DONJON,             MOULIN,             POTION,             BOUCLIER,           CROCO_AUX_CROCS_CROCHUS },
					/* 2 */{ GRENOUILLE_EPEISTE,    SAVON,              MONTRE,             GARDE_BATRACIEN,    EMPTY,              CROCO_AUX_CROCS_CROCHUS },
					/* 3 */{ POT_DE_VIN,            VEUVE_ASTUCIEUSE,   LAPIN_VIGILANT,     EMPTY,              DRUIDE_DISCRETE,    EGLISE },
                    /* 4 */{ THE_EPICE,             ESCROQUERIE,        EMPTY,              TAVERNE,            SORCIER_MALADROIT,  BARIBAL_BARBARE },
					/* 5 */{ RONGEUR_RUSE,          EMPTY,              MAGE_SENSIBLE,      AGRESSION,          PIRATE_PATATE,      INCENDIE },
                    /* 6 */{ RONGEUR_RUSE,          CHANTAGE,           PHARE,              MAGICIEN_MEFIANT,   MALEDICTION,        TOME }
                };
    }
}


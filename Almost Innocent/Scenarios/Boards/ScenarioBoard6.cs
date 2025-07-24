using Almost_Innocent.Cards;

using static Almost_Innocent.Cards.CrimeCard;
using static Almost_Innocent.Cards.EmptyCard;
using static Almost_Innocent.Cards.EvidenceCard;
using static Almost_Innocent.Cards.GuiltyCard;
using static Almost_Innocent.Cards.PlaceCard;
using static Almost_Innocent.Cards.VictimCard;

namespace Almost_Innocent.Scenarios.Boards
{
    public class ScenarioBoard6 : BaseBoard
    {
        public ScenarioBoard6()
            : base(BuildBoard)
        {
        }

        private static BaseCard[,] BuildBoard
            => new BaseCard[6, 6] // Lignes, Colonnes
				{
							 /* A */            /* B */             /* C */             /* D */         /* E */                     /* F */
					/* 1 */{ GARDE_BATRACIEN,   RONGEUR_RUSE,       BARIBAL_BARBARE,    BOUCLIER,       MAGICIEN_MEFIANT,           AGRESSION},
					/* 2 */{ GARDE_BATRACIEN,   POT_DE_VIN,         TAVERNE,            MALEDICTION,    VEUVE_ASTUCIEUSE,           DRUIDE_DISCRETE},
					/* 3 */{ ESCROQUERIE,       SORCIER_MALADROIT,  DONJON,             DONJON,         MOULIN,                     POTION },
                    /* 4 */{ PHARE,             INCENDIE,           DONJON,             DONJON,         TOME,                       MAGE_SENSIBLE },
					/* 5 */{ MONTRE,            EMPTY,              THE_EPICE,          SAVON,          CHANTAGE,                   GRENOUILLE_EPEISTE },
                    /* 6 */{ CABANE,            LAPIN_VIGILANT,     PIRATE_PATATE,      EGLISE,         CROCO_AUX_CROCS_CROCHUS,    GRENOUILLE_EPEISTE }
                };
    }
}


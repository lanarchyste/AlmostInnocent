using Almost_Innocent.Cards;

using static Almost_Innocent.Cards.CrimeCard;
using static Almost_Innocent.Cards.EmptyCard;
using static Almost_Innocent.Cards.EvidenceCard;
using static Almost_Innocent.Cards.PlaceCard;
using static Almost_Innocent.Cards.VictimCard;

namespace Almost_Innocent.Scenarios.Boards
{
	public class ScenarioBoard3 : BaseBoard
	{
		public ScenarioBoard3()
            : base(BuildBoard)
        {
		}

        private static BaseCard[,] BuildBoard
            => new BaseCard[6, 6] // Lignes, Colonnes
				{
							 /* A */			/* B */			/* C */				/* D */					/* E */		/* F */
					/* 1 */{ EMPTY,				EGLISE,			GARDE_BATRACIEN,	CHANTAGE,				DONJON,		EMPTY },
					/* 2 */{ POTION,			EMPTY,			POT_DE_VIN,			GRENOUILLE_EPEISTE,		EMPTY,		BOUCLIER },
					/* 3 */{ VEUVE_ASTUCIEUSE,	ESCROQUERIE,	LAPIN_VIGILANT,		LAPIN_VIGILANT,			AGRESSION,	THE_EPICE },
                    /* 4 */{ TOME,				MONTRE,			LAPIN_VIGILANT,		LAPIN_VIGILANT,			CABANE,		EMPTY},
					/* 5 */{ SAVON,				EMPTY,			SORCIER_MALADROIT,	INCENDIE,				EMPTY,		TAVERNE},
                    /* 6 */{ EMPTY,				PHARE,			MALEDICTION,		MAGE_SENSIBLE,			MOULIN,		EMPTY}
                };

        public override List<string> Questions
            => CommonQuestions.Concat(BuildQuestionsRelatedToScenario()).ToList();
    }
}


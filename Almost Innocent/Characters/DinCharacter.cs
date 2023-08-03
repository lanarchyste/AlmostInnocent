using Almost_Innocent.Cards;
using Almost_Innocent.Scenarios.Boards;
using Almost_Innocent.Toolkit;

namespace Almost_Innocent.Characters
{
    public class DinCharacter : BaseCharacter
	{
        public static void UseCapacity(BaseBoard board, List<CardType> cardTypes)
		{
            for (var i = 0; i < 3; i++)
            {
                var cardType = Random(cardTypes);
                switch (cardType)
                {
                    case CardType.Guilty:
                        {
                            var card = GuiltyCard.Random(false);
                            var position = board.GetPosition(card);
                            ColorConsole.WriteEmbeddedColor($"\tÉliminer le [Gray]coupable {card.Name.Replace('_', ' ').ToUpperInvariant()}[/Gray] ({position})", true);
                            break;
                        }

                    case CardType.Crime:
                        {
                            var card = CrimeCard.Random(false);
                            var position = board.GetPosition(card);
                            ColorConsole.WriteEmbeddedColor($"\tÉliminer le [Yellow]crime {card.Name.Replace('_', ' ').ToUpperInvariant()}[/Yellow] ({position})", true);
                            break;
                        }

                    case CardType.Victim:
                        {
                            var card = VictimCard.Random(false);
                            var position = board.GetPosition(card);
                            ColorConsole.WriteEmbeddedColor($"\tÉliminer la [Blue]victime {card.Name.Replace('_', ' ').ToUpperInvariant()}[/Blue] ({position})", true);
                            break;
                        }

                    case CardType.Place:
                        {
                            var card = PlaceCard.Random(false);
                            var position = board.GetPosition(card);
                            ColorConsole.WriteEmbeddedColor($"\tÉliminer le [DarkYellow]lieu {card.Name.Replace('_', ' ').ToUpperInvariant()}[/DarkYellow] ({position})", true);
                            break;
                        }

                    case CardType.Evidence:
                        {
                            var card = EvidenceCard.Random(false);
                            var position = board.GetPosition(card);
                            ColorConsole.WriteEmbeddedColor($"\tÉliminer la [Green]preuve {card.Name.Replace('_', ' ').ToUpperInvariant()}[/Green] ({position})", true);
                            break;
                        }
                }

                cardTypes = cardTypes.Where(c => c != cardType).ToList();
            }
        }
    }
}


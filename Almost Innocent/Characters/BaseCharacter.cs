using Almost_Innocent.Cards;

namespace Almost_Innocent.Characters
{
    public abstract class BaseCharacter
    {
        protected static CardType Random(List<CardType> cardTypes)
        {
            var random = new Random();

            int index = random.Next(cardTypes.Count);
            return cardTypes[index];
        }
    }
}


namespace Almost_Innocent.Cards
{
    public class EmptyCard : BaseCard
    {
        private EmptyCard()
            : base(string.Empty, string.Empty, false)
        {
        }

        public static EmptyCard EMPTY => new();
    }
}


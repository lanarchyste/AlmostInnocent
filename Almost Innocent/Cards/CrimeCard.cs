namespace Almost_Innocent.Cards
{
    //Carte crime
    public class CrimeCard : BaseCard
	{
		public CrimeCard(string name, bool isAdditionalClue = false)
            : base(name, isAdditionalClue)
        {
		}

        public static CrimeCard INCENDIE => new("INCENDIE");

        public static CrimeCard MALEDICTION => new("MALEDICTION");

        public static CrimeCard POT_DE_VIN => new("POT_DE_VIN");

        public static CrimeCard CHANTAGE => new("CHANTAGE");

        public static CrimeCard AGRESSION => new("AGRESSION");

        public static CrimeCard ESCROQUERIE => new("ESCROQUERIE");

        public static CrimeCard Random()
        {
            var random = new Random();

            int index = random.Next(All.Count);
            return All[index];
        }

        public static List<CrimeCard> All
            => new() { INCENDIE, MALEDICTION, POT_DE_VIN, CHANTAGE, AGRESSION, ESCROQUERIE };
    }
}


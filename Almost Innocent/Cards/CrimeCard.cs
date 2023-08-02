namespace Almost_Innocent.Cards
{
    //Carte crime (jaune)
    public class CrimeCard : BaseCard
	{
		public CrimeCard(string name, string text, bool isAdditionalClue = false)
            : base(name, text, isAdditionalClue)
        {
		}

        public static CrimeCard INCENDIE => new("INCENDIE", "a un peu trop mis le feu à");

        public static CrimeCard MALEDICTION => new("MALEDICTION", "a béni négativement");

        public static CrimeCard POT_DE_VIN => new("POT_DE_VIN", "a tenté financièrement");

        public static CrimeCard CHANTAGE => new("CHANTAGE", "a évoqué certains différents avec");

        public static CrimeCard AGRESSION => new("AGRESSION", "a libéré de ses possessions");

        public static CrimeCard ESCROQUERIE => new("ESCROQUERIE", "a induit en erreur");

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


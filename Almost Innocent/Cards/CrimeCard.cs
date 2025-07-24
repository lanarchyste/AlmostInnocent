namespace Almost_Innocent.Cards
{
    //Carte crime (jaune)
    public class CrimeCard : BaseCard
    {
        private static List<CrimeCard> _available = All;

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

        public static CrimeCard Random(bool isPick = true)
        {
            var cardSelected = Random(_available);

            if (isPick)
                _available = [.. _available.Where(c => c != cardSelected)];

            return cardSelected;
        }

        public static List<CrimeCard> All
            => [INCENDIE, MALEDICTION, POT_DE_VIN, CHANTAGE, AGRESSION, ESCROQUERIE];

        public static List<CrimeCard> Available
            => _available;
    }
}


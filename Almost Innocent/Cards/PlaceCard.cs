namespace Almost_Innocent.Cards
{
    //Carte lieu (orange)
    public class PlaceCard : BaseCard
	{
		public PlaceCard(string name, string text, bool isAdditionalClue = false)
			: base(name, text, isAdditionalClue)
		{
		}

		public static PlaceCard MOULIN => new("MOULIN", "dans un moulin partagé");

        public static PlaceCard TAVERNE => new("TAVERNE", "dans une taverne prestigieuse");

        public static PlaceCard EGLISE => new("EGLISE", "dans un temple miséricordieux");

        public static PlaceCard PHARE => new("PHARE", "dans une tour reculée");

        public static PlaceCard CABANE => new("CABANE", "dans une cabane ignifugée");

        public static PlaceCard DONJON => new("DONJON", "dans une forteresse chaleureuse");

        public static PlaceCard Random(List<PlaceCard> cards)
        {
            var random = new Random();

            int index = random.Next(cards.Count);
            return cards[index];
        }

        public static List<PlaceCard> All
            => new() { MOULIN, TAVERNE, EGLISE, PHARE, CABANE, DONJON };
    }
}


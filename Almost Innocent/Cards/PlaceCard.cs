namespace Almost_Innocent.Cards
{
    //Carte lieu
    public class PlaceCard : BaseCard
	{
		public PlaceCard(string name, bool isAdditionalClue = false)
			: base(name, isAdditionalClue)
		{
		}

		public static PlaceCard MOULIN => new("MOULIN");

        public static PlaceCard TAVERNE => new("TAVERNE");

        public static PlaceCard EGLISE => new("EGLISE");

        public static PlaceCard PHARE => new("PHARE");

        public static PlaceCard CABANE => new("CABANE");

        public static PlaceCard DONJON => new("DONJON");

        public static PlaceCard Random()
        {
            var random = new Random();

            int index = random.Next(All.Count);
            return All[index];
        }

        public static List<PlaceCard> All
            => new() { MOULIN, TAVERNE, EGLISE, PHARE, CABANE, DONJON };
    }
}


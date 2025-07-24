namespace Almost_Innocent.Cards
{
    //Carte lieu (orange)
    public class PlaceCard : BaseCard
    {
        private static List<PlaceCard> _available = All;

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

        public static PlaceCard Random(bool isPick = true)
        {
            var cardSelected = Random(_available);

            if (isPick)
                _available = _available.Where(c => c != cardSelected).ToList();

            return cardSelected;
        }

        public static List<PlaceCard> All
            => new() { MOULIN, TAVERNE, EGLISE, PHARE, CABANE, DONJON };

        public static List<PlaceCard> Available
            => _available;
    }
}


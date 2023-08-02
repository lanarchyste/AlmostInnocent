namespace Almost_Innocent.Cards
{
    //Carte preuve
    public class EvidenceCard: BaseCard
    {
		public EvidenceCard(string name, bool isAdditionalClue = false)
			: base(name, isAdditionalClue)
		{
		}

        public static EvidenceCard MONTRE => new("MONTRE");

        public static EvidenceCard SAVON => new("SAVON");
		 
		public static EvidenceCard TOME => new("TOME");

        public static EvidenceCard BOUCLIER => new("BOUCLIER");

        public static EvidenceCard POTION => new("POTION");

        public static EvidenceCard THE_EPICE => new("THE_EPICE");

        public static EvidenceCard Random()
        {
            var random = new Random();

            int index = random.Next(All.Count);
            return All[index];
        }

        public static List<EvidenceCard> All
            => new() { MONTRE, SAVON, TOME, BOUCLIER, POTION, THE_EPICE };
    }
}


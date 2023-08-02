namespace Almost_Innocent.Cards
{
    //Carte preuve (Vert)
    public class EvidenceCard: BaseCard
    {
		public EvidenceCard(string name, string text, bool isAdditionalClue = false)
			: base(name, text, isAdditionalClue)
		{
		}

        public static EvidenceCard MONTRE => new("MONTRE", "avec une montre de contrefaçon.");

        public static EvidenceCard SAVON => new("SAVON", "avec une odeur suspecte.");
		 
		public static EvidenceCard TOME => new("TOME", "avec un almanach mal écrit.");

        public static EvidenceCard BOUCLIER => new("BOUCLIER", "avec un superbe blindage.");

        public static EvidenceCard POTION => new("POTION", "avec une mixture à l'arachide.");

        public static EvidenceCard THE_EPICE => new("THE_EPICE", "à l'aide d'une boisson quasi légale.");

        public static EvidenceCard Random(List<EvidenceCard> cards)
        {
            var random = new Random();

            int index = random.Next(cards.Count);
            return cards[index];
        }

        public static List<EvidenceCard> All
            => new() { MONTRE, SAVON, TOME, BOUCLIER, POTION, THE_EPICE };
    }
}


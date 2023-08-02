namespace Almost_Innocent.Cards
{
    //Carte victime
    public class VictimCard : BaseCard
    {
		public VictimCard(string name, bool isAdditionalClue = false)
			: base(name, isAdditionalClue)
		{
		}

        public static VictimCard VEUVE_ASTUCIEUSE => new("VEUVE_ASTUCIEUSE");

        public static VictimCard LAPIN_VIGILANT => new("LAPIN_VIGILANT");

        public static VictimCard SORCIER_MALADROIT => new("SORCIER_MALADROIT");

        public static VictimCard GARDE_BATRACIEN => new("GARDE_BATRACIEN");

        public static VictimCard GRENOUILLE_EPEISTE => new("GRENOUILLE_EPEISTE");

        public static VictimCard MAGE_SENSIBLE => new("MAGE_SENSIBLE");

        public static VictimCard Random()
        {
            var random = new Random();

            int index = random.Next(All.Count);
            return All[index];
        }

        public static List<VictimCard> All
            => new() { VEUVE_ASTUCIEUSE, LAPIN_VIGILANT, SORCIER_MALADROIT, GARDE_BATRACIEN, GRENOUILLE_EPEISTE, MAGE_SENSIBLE };
    }
}


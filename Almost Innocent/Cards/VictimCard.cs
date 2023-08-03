namespace Almost_Innocent.Cards
{
    //Carte victime (bleu)
    public class VictimCard : BaseCard
    {
        private static List<VictimCard> _available = All;

        public VictimCard(string name, string text, bool isAdditionalClue = false)
			: base(name, text, isAdditionalClue)
		{
		}

        public static VictimCard VEUVE_ASTUCIEUSE => new("VEUVE_ASTUCIEUSE", "une personne en deuil brillante");

        public static VictimCard LAPIN_VIGILANT => new("LAPIN_VIGILANT", "un garde inébranlable");

        public static VictimCard SORCIER_MALADROIT => new("SORCIER_MALADROIT", "un mage doté de mains qui glissent");

        public static VictimCard GARDE_BATRACIEN => new("GARDE_BATRACIEN", "un crapaud sous-payé");

        public static VictimCard GRENOUILLE_EPEISTE => new("GRENOUILLE_EPEISTE", "un soldat agité");

        public static VictimCard MAGE_SENSIBLE => new("MAGE_SENSIBLE", "un conjurateur réputé");

        public static VictimCard Random(bool isPick = true)
        {
            var cardSelected = Random(_available);

            if (isPick)
                _available = _available.Where(c => c != cardSelected).ToList();

            return cardSelected;
        }

        public static List<VictimCard> All
            => new() { VEUVE_ASTUCIEUSE, LAPIN_VIGILANT, SORCIER_MALADROIT, GARDE_BATRACIEN, GRENOUILLE_EPEISTE, MAGE_SENSIBLE };

        public static List<VictimCard> Availables
            => _available;
    }
}


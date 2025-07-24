namespace Almost_Innocent.Cards
{
    //Carte coupable (gris/noir)
    public class GuiltyCard : BaseCard
    {
        private static List<GuiltyCard> _available = All;

        private GuiltyCard(string name, string text, bool isAdditionalClue = false)
            : base(name, text, isAdditionalClue)
        {
        }

        public static GuiltyCard BARIBAL_BARBARE => new("BARIBAL_BARBARE", "un videur de mauvais poil");

        public static GuiltyCard RONGEUR_RUSE => new("RONGEUR_RUSE", "une souris fautrice de troubles");

        public static GuiltyCard MAGICIEN_MEFIANT => new("MAGICIEN_MEFIANT", "un sorcier somnolent");

        public static GuiltyCard DRUIDE_DISCRETE => new("DRUIDE_DISCRETE", "une herboriste audacieuse");

        public static GuiltyCard CROCO_AUX_CROCS_CROCHUS => new("CROCO_AUX_CROCS_CROCHUS", "un reptile insistant");

        public static GuiltyCard PIRATE_PATATE => new("PIRATE_PATATE", "un marchand furtif");

        public static GuiltyCard Random(bool isPick = true)
        {
            var cardSelected = Random(_available);

            if (isPick)
                _available = [.. _available.Where(c => c != cardSelected)];

            return cardSelected;
        }

        public static List<GuiltyCard> All
            => [BARIBAL_BARBARE, RONGEUR_RUSE, MAGICIEN_MEFIANT, DRUIDE_DISCRETE, CROCO_AUX_CROCS_CROCHUS, PIRATE_PATATE];

        public static List<GuiltyCard> Available
            => _available;
    }
}


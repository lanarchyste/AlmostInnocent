namespace Almost_Innocent.Cards
{
    //Carte coupable
    public class GuiltyCard : BaseCard
    {
        public GuiltyCard(string name, bool isAdditionalClue = false)
            : base(name, isAdditionalClue)
        {
        }

        public static GuiltyCard BARIBAL_BARBARE => new("BARIBAL_BARBARE");

        public static GuiltyCard RONGEUR_RUSE => new("RONGEUR_RUSE");

        public static GuiltyCard MAGICIEN_MEFIANT => new("MAGICIEN_MEFIANT");

        public static GuiltyCard DRUIDE_DISCRETE => new("DRUIDE_DISCRETE");

        public static GuiltyCard CROCO_AUX_CROCS_CROCHUS => new("CROCO_AUX_CROCS_CROCHUS");

        public static GuiltyCard PIRATE_PATATE => new("PIRATE_PATATE");

        public static GuiltyCard Random()
        {
            var random = new Random();

            int index = random.Next(All.Count);
            return All[index];
        }

        public static List<GuiltyCard> All
            => new() { BARIBAL_BARBARE, RONGEUR_RUSE, MAGICIEN_MEFIANT, DRUIDE_DISCRETE, CROCO_AUX_CROCS_CROCHUS, PIRATE_PATATE };
    }
}


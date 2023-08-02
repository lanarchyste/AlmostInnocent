using Almost_Innocent.Cards;
using Almost_Innocent.Scenarios.Boards;
using Almost_Innocent.Toolkit;

namespace Almost_Innocent.Scenarios
{
	public class Scenario5 : BaseScenario, IScenario
    {
		public Scenario5(bool isIAEnabled, int totalSurveyTokens, int numberSurveyTokens, int cardSurveyTokens, int almostInnocentTokens)
            : base(new ScenarioBoard5(), new("^(#|V|VICTIME |BLEU |P|PREUVE |VERT |L|LIEU |ORANGE |CR|CRIME |JAUNE |CO|COUPABLE |NOIR ){1}[A-F1-6]{1}$"), isIAEnabled, totalSurveyTokens, numberSurveyTokens, cardSurveyTokens, almostInnocentTokens)
        {
            CrimeCard = CrimeCard.Random();
            VictimCard = VictimCard.Random();
            EvidenceCard = EvidenceCard.Random();
            PlaceCard = PlaceCard.Random();
            GuiltyCard = GuiltyCard.Random();
        }

        public CrimeCard CrimeCard { get; }

        public VictimCard VictimCard { get; }

        public EvidenceCard EvidenceCard { get; }

        public PlaceCard PlaceCard { get; }

        public GuiltyCard GuiltyCard { get; }

        public void Launch()
            => InternalLaunch();

        public static Scenario5 Setup()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"\tScénario 5 - Un croco à l'oeil vif");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();

            Console.WriteLine("Définissez le niveau de difficulté du sénario :");
            Console.WriteLine("\t1 : Facile");
            Console.WriteLine("\t2 : Moyen");
            Console.WriteLine("\t3 : Détective");
            Console.Write("Qu'elle niveau voulez-vous ? ");
            var difficultyLevel = SetDifficultyLevel();

            Console.WriteLine();
            Console.Write("Voulez-vous activer l'IA [O/N] ? ");
            var isIAEnabled = SetIA();

            Console.WriteLine();
            return Create(difficultyLevel, isIAEnabled);
        }

        protected override string Question(string question)
            => ScenarioBoard.Question(question, new() { CrimeCard, VictimCard, EvidenceCard, PlaceCard, GuiltyCard });

        protected override void SolvingCombinations()
        {
            try
            {
                ReadCombination(VictimCard.All.Cast<BaseCard>().ToList(), VictimCard, "Qu'elle est la [Yellow]victime[/Yellow] ? ");
                ReadCombination(CrimeCard.All.Cast<BaseCard>().ToList(), CrimeCard, "Qu'elle est le [Yellow]crime[/Yellow] ? ");
                ReadCombination(EvidenceCard.All.Cast<BaseCard>().ToList(), EvidenceCard, "Qu'elle est la [Yellow]preuve[/Yellow] ? ");
                ReadCombination(PlaceCard.All.Cast<BaseCard>().ToList(), PlaceCard, "Qu'elle est le [Yellow]lieu[/Yellow] ? ");
                ReadCombination(GuiltyCard.All.Cast<BaseCard>().ToList(), GuiltyCard, "Qu'elle est le [Yellow]coupable[/Yellow] ? ");

                Console.Write("FELICITATIONS ! Vous avez gagné");
            }
            catch (LostGameException)
            {
                ColorConsole.WriteLine("Vous avez perdu !", ConsoleColor.Red);
            }
        }

        private static Scenario5 Create(DIFFICULTY_LEVEL level, bool isIAEnabled)
            => level switch
            {
                DIFFICULTY_LEVEL.DETECTIVE => new Scenario5(isIAEnabled, 10, 7, 3, 0),
                DIFFICULTY_LEVEL.MEDIUM => new Scenario5(isIAEnabled, 11, 8, 3, 1),
                _ => new Scenario5(isIAEnabled, 12, 9, 3, 2),
            };
    }
}


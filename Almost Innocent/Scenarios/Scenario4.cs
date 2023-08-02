using Almost_Innocent.Cards;
using Almost_Innocent.Scenarios.Boards;
using Almost_Innocent.Toolkit;

namespace Almost_Innocent.Scenarios
{
    public class Scenario4 : BaseScenario, IScenario
    {
		public Scenario4(bool isIAEnabled, int totalSurveyTokens, int numberSurveyTokens, int cardSurveyTokens, int almostInnocentTokens)
            : base(new ScenarioBoard4(), new("^(#|V|VICTIME |BLEU |P|PREUVE |VERT |L|LIEU |ORANGE |CR|CRIME |JAUNE ){1}[A-F1-6]{1}$"), isIAEnabled, totalSurveyTokens, numberSurveyTokens, cardSurveyTokens, almostInnocentTokens)
        {
            CrimeCard = CrimeCard.Random();
            VictimCard = VictimCard.Random();
            EvidenceCard = EvidenceCard.Random();
            PlaceCard = PlaceCard.Random();
        }

        public CrimeCard CrimeCard { get; }

        public VictimCard VictimCard { get; }

        public EvidenceCard EvidenceCard { get; }

        public PlaceCard PlaceCard { get; }

        public void Launch()
            => InternalLaunch();

        public static Scenario4 Setup()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"\tScénario 4 - Ça saute au yeux !");
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

        protected override List<string> AllQuestions
            => ScenarioBoard.AllQuestions.Where(q => !q.StartsWith("CO")).ToList();

        protected override string Question(string question)
            => ScenarioBoard.Question(question, new() { CrimeCard, VictimCard, EvidenceCard, PlaceCard });

        protected override void SolvingCombinations()
        {
            try
            {
                ReadCombination(VictimCard.All.Cast<BaseCard>().ToList(), VictimCard, "Qu'elle est la [Yellow]victime[/Yellow] ? ");
                ReadCombination(CrimeCard.All.Cast<BaseCard>().ToList(), CrimeCard, "Qu'elle est le [Yellow]crime[/Yellow] ? ");
                ReadCombination(EvidenceCard.All.Cast<BaseCard>().ToList(), EvidenceCard, "Qu'elle est la [Yellow]preuve[/Yellow] ? ");
                ReadCombination(PlaceCard.All.Cast<BaseCard>().ToList(), PlaceCard, "Qu'elle est le [Yellow]lieu[/Yellow] ? ");

                //TODO: Définir une échelle de réussite entre le nombre de jetons d'indice / quasi-innocent
                Console.Write("FELICITATIONS ! Vous avez gagné");
            }
            catch (LostGameException)
            {
                ColorConsole.WriteLine("Vous avez perdu !", ConsoleColor.Red);
            }
        }

        private static Scenario4 Create(DIFFICULTY_LEVEL level, bool isIAEnabled)
            => level switch
            {
                DIFFICULTY_LEVEL.DETECTIVE => new Scenario4(isIAEnabled, 8, 5, 3, 0),
                DIFFICULTY_LEVEL.MEDIUM => new Scenario4(isIAEnabled, 10, 6, 4, 1),
                _ => new Scenario4(isIAEnabled, 12, 8, 4, 2),
            };
    }
}


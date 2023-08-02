using Almost_Innocent.Cards;
using Almost_Innocent.Scenarios.Boards;
using Almost_Innocent.Toolkit;

namespace Almost_Innocent.Scenarios
{
    public class Scenario1 : BaseScenario, IScenario
    {
        public Scenario1(bool isIAEnabled, bool isGameStartWwithClues, int totalSurveyTokens, int almostInnocentTokens)
            : base(new ScenarioBoard1(), new("^(#|V|VICTIME |BLEU |P|PREUVE |VERT |L|LIEU |ORANGE |CR|CRIME |JAUNE ){1}[A-F1-6]{1}$"), isIAEnabled, isGameStartWwithClues, totalSurveyTokens, totalSurveyTokens, totalSurveyTokens, almostInnocentTokens)
		{
            CrimeCard = CrimeCard.Random(CrimeCard.All);
            VictimCard = VictimCard.Random(VictimCard.All);
            PlaceCard = PlaceCard.Random(PlaceCard.All);
            EvidenceCard = EvidenceCard.Random(EvidenceCard.All);
        }

		public CrimeCard CrimeCard { get; }

        public VictimCard VictimCard { get; }

        public EvidenceCard EvidenceCard { get; }

        public PlaceCard PlaceCard { get; }

        public void Launch()
        {
            if (IsGameStartWwithClues)
            {
                var crimeCard = CrimeCard.Random(CrimeCard.All.Where(c => c != CrimeCard).ToList());
                var crimePosition = ScenarioBoard.GetPosition(crimeCard);

                var victimCard = VictimCard.Random(VictimCard.All.Where(c => c != VictimCard).ToList());
                var victimPosition = ScenarioBoard.GetPosition(victimCard);

                var placeCard = PlaceCard.Random(PlaceCard.All.Where(c => c != PlaceCard).ToList());
                var placePosition = ScenarioBoard.GetPosition(placeCard);

                var evidenceCard = EvidenceCard.Random(EvidenceCard.All.Where(c => c != EvidenceCard).ToList());
                var evidencePosition = ScenarioBoard.GetPosition(evidenceCard);

                Console.WriteLine("Voici vos indices de départ :");
                ColorConsole.WriteEmbeddedColor($"\tÉliminer le [Yellow]crime {crimeCard.Name.Replace('_', ' ').ToUpperInvariant()}[/Yellow] ({crimePosition})", true);
                ColorConsole.WriteEmbeddedColor($"\tÉliminer la [Blue]victime {victimCard.Name.Replace('_', ' ').ToUpperInvariant()}[/Blue] ({victimPosition})", true);
                ColorConsole.WriteEmbeddedColor($"\tÉliminer le [DarkYellow]lieu {placeCard.Name.Replace('_', ' ').ToUpperInvariant()}[/DarkYellow] ({placePosition})", true);
                ColorConsole.WriteEmbeddedColor($"\tÉliminer la [Green]preuve {evidenceCard.Name.Replace('_', ' ').ToUpperInvariant()}[/Green] ({evidencePosition})", true);

                Console.WriteLine();
                Console.WriteLine("Appuyer sur une touche dès que vous êtes prêt pour commencer la partie !");
                Console.ReadKey();
                Console.WriteLine();
            }

            InternalLaunch();
        }

        public static Scenario1 Setup()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"\tScénario 1 - Une tournée fatale");
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
            var isIAEnabled = SetYesOrNo();

            Console.WriteLine();
            Console.Write("Voulez-vous obtenir des indices en début de partie [O/N] ? ");
            var isGameStartWwithClues = SetYesOrNo();

            Console.WriteLine();
            return Create(difficultyLevel, isIAEnabled, isGameStartWwithClues);
        }

        protected override string Question(string question)
            => ScenarioBoard.Question(question, new() { CrimeCard, VictimCard, EvidenceCard, PlaceCard });

        protected override void SolvingCombinations()
        {
            try
            {
                ReadCombination(CrimeCard.All.Cast<BaseCard>().ToList(), CrimeCard, "Qu'elle est le [Yellow]crime[/Yellow] ? ");
                ReadCombination(VictimCard.All.Cast<BaseCard>().ToList(), VictimCard, "Qu'elle est la [Blue]victime[/Blue] ? ");
                ReadCombination(PlaceCard.All.Cast<BaseCard>().ToList(), PlaceCard, "Qu'elle est le [DarkYellow]lieu[/DarkYellow] ? ");
                ReadCombination(EvidenceCard.All.Cast<BaseCard>().ToList(), EvidenceCard, "Qu'elle est la [Green]preuve[/Green] ? ");

                Console.WriteLine("Félicitations, vous avez gagné !");
                ColorConsole.Write($"Votre enquête réussie, vous concluez que le coupable {BuildHistory(new() { CrimeCard, VictimCard, EvidenceCard, PlaceCard })}", ConsoleColor.Yellow);
            }
            catch(LostGameException)
            {
                ColorConsole.Write("Vous avez perdu !", ConsoleColor.Red);
            }
        }

        private static Scenario1 Create(DIFFICULTY_LEVEL level, bool isIAEnabled, bool isGameStartWwithClues)
		    => level switch
            {
                DIFFICULTY_LEVEL.DETECTIVE => new Scenario1(isIAEnabled, isGameStartWwithClues, 8, 0),
                DIFFICULTY_LEVEL.MEDIUM => new Scenario1(isIAEnabled, isGameStartWwithClues, 10, 1),
                _ => new Scenario1(isIAEnabled, isGameStartWwithClues, 12, 2),
            };
    }
}


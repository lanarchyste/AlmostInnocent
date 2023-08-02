using Almost_Innocent.Cards;
using Almost_Innocent.Scenarios.Boards;
using Almost_Innocent.Toolkit;

namespace Almost_Innocent.Scenarios
{
    public class Scenario4 : BaseScenario, IScenario
    {
		public Scenario4(bool isIAEnabled, bool isGameStartWwithClues, int totalSurveyTokens, int numberSurveyTokens, int cardSurveyTokens, int almostInnocentTokens)
            : base(new ScenarioBoard4(), new("^(#|V|VICTIME |BLEU |P|PREUVE |VERT |L|LIEU |ORANGE |CR|CRIME |JAUNE ){1}[A-F1-6]{1}$"), isIAEnabled, isGameStartWwithClues, totalSurveyTokens, numberSurveyTokens, cardSurveyTokens, almostInnocentTokens)
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
            catch (LostGameException)
            {
                ColorConsole.Write("Vous avez perdu !", ConsoleColor.Red);
            }
        }

        private static Scenario4 Create(DIFFICULTY_LEVEL level, bool isIAEnabled, bool isGameStartWwithClues)
            => level switch
            {
                DIFFICULTY_LEVEL.DETECTIVE => new Scenario4(isIAEnabled, isGameStartWwithClues, 8, 5, 3, 0),
                DIFFICULTY_LEVEL.MEDIUM => new Scenario4(isIAEnabled, isGameStartWwithClues, 10, 6, 4, 1),
                _ => new Scenario4(isIAEnabled, isGameStartWwithClues, 12, 8, 4, 2),
            };
    }
}


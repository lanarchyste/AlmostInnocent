using Almost_Innocent.Cards;
using Almost_Innocent.Scenarios.Boards;
using Almost_Innocent.Toolkit;

namespace Almost_Innocent.Scenarios
{
	public class Scenario5 : BaseScenario, IScenario
    {
		public Scenario5(bool isIAEnabled, bool isGameStartWwithClues, int totalSurveyTokens, int numberSurveyTokens, int cardSurveyTokens, int almostInnocentTokens)
            : base(new ScenarioBoard5(), new("^(#|V|VICTIME |BLEU |P|PREUVE |VERT |L|LIEU |ORANGE |CR|CRIME |JAUNE |CO|COUPABLE |NOIR ){1}[A-F1-6]{1}$"), isIAEnabled, isGameStartWwithClues, totalSurveyTokens, numberSurveyTokens, cardSurveyTokens, almostInnocentTokens)
        {
            GuiltyCard = GuiltyCard.Random(GuiltyCard.All);
            CrimeCard = CrimeCard.Random(CrimeCard.All);
            VictimCard = VictimCard.Random(VictimCard.All);
            PlaceCard = PlaceCard.Random(PlaceCard.All);
            EvidenceCard = EvidenceCard.Random(EvidenceCard.All);
        }

        public CrimeCard CrimeCard { get; }

        public VictimCard VictimCard { get; }

        public EvidenceCard EvidenceCard { get; }

        public PlaceCard PlaceCard { get; }

        public GuiltyCard GuiltyCard { get; }

        public void Launch()
        {
            if (IsGameStartWwithClues)
            {
                var guiltyCard = GuiltyCard.Random(GuiltyCard.All.Where(c => c != GuiltyCard).ToList());
                var guiltyPosition = ScenarioBoard.GetPosition(guiltyCard);

                var crimeCard = CrimeCard.Random(CrimeCard.All.Where(c => c != CrimeCard).ToList());
                var crimePosition = ScenarioBoard.GetPosition(crimeCard);

                var victimCard = VictimCard.Random(VictimCard.All.Where(c => c != VictimCard).ToList());
                var victimPosition = ScenarioBoard.GetPosition(victimCard);

                var placeCard = PlaceCard.Random(PlaceCard.All.Where(c => c != PlaceCard).ToList());
                var placePosition = ScenarioBoard.GetPosition(placeCard);

                var evidenceCard = EvidenceCard.Random(EvidenceCard.All.Where(c => c != EvidenceCard).ToList());
                var evidencePosition = ScenarioBoard.GetPosition(evidenceCard);

                Console.WriteLine("Voici vos indices de départ :");
                ColorConsole.WriteEmbeddedColor($"\tÉliminer le [Gray]coupable {guiltyCard.Name.Replace('_', ' ').ToUpperInvariant()}[/Gray] ({guiltyPosition})", true);
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
            var isIAEnabled = SetYesOrNo();

            Console.WriteLine();
            Console.Write("Voulez-vous obtenir des indices en début de partie [O/N] ? ");
            var isGameStartWwithClues = SetYesOrNo();

            Console.WriteLine();
            return Create(difficultyLevel, isIAEnabled, isGameStartWwithClues);
        }

        protected override string Question(string question)
            => ScenarioBoard.Question(question, new() { CrimeCard, VictimCard, EvidenceCard, PlaceCard, GuiltyCard });

        protected override void SolvingCombinations()
        {
            try
            {
                ReadCombination(GuiltyCard.All.Cast<BaseCard>().ToList(), GuiltyCard, "Qu'elle est le [Gray]coupable[/Gray] ? ");
                ReadCombination(CrimeCard.All.Cast<BaseCard>().ToList(), CrimeCard, "Qu'elle est le [Yellow]crime[/Yellow] ? ");
                ReadCombination(VictimCard.All.Cast<BaseCard>().ToList(), VictimCard, "Qu'elle est la [Blue]victime[/Blue] ? ");
                ReadCombination(PlaceCard.All.Cast<BaseCard>().ToList(), PlaceCard, "Qu'elle est le [DarkYellow]lieu[/DarkYellow] ? ");
                ReadCombination(EvidenceCard.All.Cast<BaseCard>().ToList(), EvidenceCard, "Qu'elle est la [Green]preuve[/Green] ? ");

                Console.WriteLine("Félicitations, vous avez gagné !");
                ColorConsole.Write($"Votre enquête réussie, vous concluez qu'{BuildHistory(new() { GuiltyCard, CrimeCard, VictimCard, EvidenceCard, PlaceCard })}", ConsoleColor.Yellow);
            }
            catch (LostGameException)
            {
                ColorConsole.Write("Vous avez perdu !", ConsoleColor.Red);
            }
        }

        private static Scenario5 Create(DIFFICULTY_LEVEL level, bool isIAEnabled, bool isGameStartWwithClues)
            => level switch
            {
                DIFFICULTY_LEVEL.DETECTIVE => new Scenario5(isIAEnabled, isGameStartWwithClues, 10, 7, 3, 0),
                DIFFICULTY_LEVEL.MEDIUM => new Scenario5(isIAEnabled, isGameStartWwithClues, 11, 8, 3, 1),
                _ => new Scenario5(isIAEnabled, isGameStartWwithClues, 12, 9, 3, 2),
            };
    }
}


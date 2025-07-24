using Almost_Innocent.Cards;
using Almost_Innocent.Scenarios.Boards;
using Almost_Innocent.Toolkit;
using System.Text.RegularExpressions;

namespace Almost_Innocent.Scenarios
{
    public class Scenario4 : BaseScenario, IScenario
    {
        private static readonly Regex _regexQuestion = new("^(#|V|VICTIME |BLEU |P|PREUVE |VERT |L|LIEU |ORANGE |CR|CRIME |JAUNE ){1}[A-F1-6]{1}$");
        private static readonly List<CardType> _cardTypes = new() { CardType.Crime, CardType.Victim, CardType.Place, CardType.Evidence };

        public Scenario4(bool isAIEnabled, bool isGameStartWithClues, int totalSurveyTokens, int numberSurveyTokens, int cardSurveyTokens, int almostInnocentTokens)
            : base(new ScenarioBoard4(), _cardTypes, _regexQuestion, null, isAIEnabled, isGameStartWithClues, totalSurveyTokens, numberSurveyTokens, cardSurveyTokens, almostInnocentTokens)
        {
            CrimeCard_AI = CrimeCard.Random();
            VictimCard_AI = VictimCard.Random();
            PlaceCard_AI = PlaceCard.Random();
            EvidenceCard_AI = EvidenceCard.Random();
        }

        public CrimeCard CrimeCard_AI { get; }

        public VictimCard VictimCard_AI { get; }

        public EvidenceCard EvidenceCard_AI { get; }

        public PlaceCard PlaceCard_AI { get; }


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
            Console.Write("Quel niveau voulez-vous [1-3] ? ");
            var difficultyLevel = SetDifficultyLevel();

            Console.WriteLine();
            Console.Write("Voulez-vous activer l'IA [O/N] ? ");
            var isAIEnabled = SetYesOrNo();

            Console.WriteLine();
            Console.Write("Voulez-vous obtenir des indices en début de partie [O/N] ? ");
            var isGameStartWwithClues = SetYesOrNo();

            Console.WriteLine();
            return Create(difficultyLevel, isAIEnabled, isGameStartWwithClues);
        }

        protected override string Question(string question)
            => ScenarioBoard.Question(question, new() { CrimeCard_AI, VictimCard_AI, EvidenceCard_AI, PlaceCard_AI });

        protected override void SolvingCombinations()
        {
            try
            {
                ReadCombination(CrimeCard.All.Cast<BaseCard>().ToList(), CrimeCard_AI, "Qu'elle est le [Yellow]crime[/Yellow] ? ");
                ReadCombination(VictimCard.All.Cast<BaseCard>().ToList(), VictimCard_AI, "Qu'elle est la [Blue]victime[/Blue] ? ");
                ReadCombination(PlaceCard.All.Cast<BaseCard>().ToList(), PlaceCard_AI, "Qu'elle est le [DarkYellow]lieu[/DarkYellow] ? ");
                ReadCombination(EvidenceCard.All.Cast<BaseCard>().ToList(), EvidenceCard_AI, "Qu'elle est la [Green]preuve[/Green] ? ");

                Console.WriteLine("Félicitations, vous avez gagné !");
                ColorConsole.Write($"Votre enquête réussie, vous concluez que le coupable {BuildHistory([CrimeCard_AI, VictimCard_AI, EvidenceCard_AI, PlaceCard_AI])}", ConsoleColor.Yellow);
            }
            catch (LostGameException)
            {
                ColorConsole.Write("Vous avez perdu !", ConsoleColor.Red);
            }
        }

        private static Scenario4 Create(DIFFICULTY_LEVEL level, bool isAIEnabled, bool isGameStartWithClues)
            => level switch
            {
                DIFFICULTY_LEVEL.DETECTIVE => new Scenario4(isAIEnabled, isGameStartWithClues, 8, 5, 3, 0),
                DIFFICULTY_LEVEL.MEDIUM => new Scenario4(isAIEnabled, isGameStartWithClues, 10, 6, 4, 1),
                _ => new Scenario4(isAIEnabled, isGameStartWithClues, 12, 8, 4, 2),
            };
    }
}


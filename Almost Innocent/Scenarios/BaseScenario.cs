using Almost_Innocent.Cards;
using Almost_Innocent.Scenarios.Boards;
using Almost_Innocent.Scenarios.Exceptions;
using Almost_Innocent.Toolkit;
using Diacritics.Extensions;
using System.Text;
using System.Text.RegularExpressions;

namespace Almost_Innocent.Scenarios
{
    public abstract class BaseScenario
    {
        private readonly Regex _regexQuestion;
        private static readonly Regex _regexDifficultyLevel = new("^[1-3]$");
        private static readonly Regex _regexIA = new("^(O|o|N|n)$");

        public BaseScenario(BaseBoard scenarioBoard, Regex regexQuestion, bool isIAEnabled, int totalSurveyTokens, int numberSurveyTokens, int cardSurveyTokens, int almostInnocentTokens)
		{
            ScenarioBoard = scenarioBoard;
            IsIAEnabled = isIAEnabled;
            TotalSurveyTokens = totalSurveyTokens;
            NumberSurveyTokens = numberSurveyTokens;
            CardSurveyTokens = cardSurveyTokens;
            AlmostInnocentTokens = almostInnocentTokens;

            _regexQuestion = regexQuestion;
        }

        public BaseBoard ScenarioBoard { get; private set; }

        public bool IsIAEnabled { get; private set; }

        public int TotalSurveyTokens { get; private set; }

        public int NumberSurveyTokens { get; private set; }

        public int CardSurveyTokens { get; private set; }

        public int AlmostInnocentTokens { get; private set; }

        public void DiscardNumberSurveyToken()
        {
            TotalSurveyTokens -= 1;
            NumberSurveyTokens -= 1;
        }

        public void DiscardCardSurveyToken()
        {
            TotalSurveyTokens -= 1;
            CardSurveyTokens -= 1;
        }

        public void DiscardAlmostInnocentToken()
        {
            AlmostInnocentTokens -= 1;
        }

        public void TurnIA(List<string> questionsAvailable)
        {
            if(!questionsAvailable.Any())
            {
                Console.Write("L'IA est dans l'incapacité de poser une question");
                return;
            }

            var random = new Random();

            int attempt = 0;
            string question;
            var mustUseNumberSurveyToken = random.Next(3) < 2;

            while (true)
            {
                attempt++;

                int index = random.Next(questionsAvailable.Count);
                question = questionsAvailable[index];

                if((mustUseNumberSurveyToken && question.StartsWith('#')) || (!mustUseNumberSurveyToken && !question.StartsWith('#')))
                    break;

                if (attempt >= (questionsAvailable.Count - 1))
                    break;
            }

            try
            {
                if (!ScenarioBoard.CheckIsLocationAvailable(question))
                {
                    questionsAvailable.Remove(question);
                    TurnIA(questionsAvailable);
                    return;
                }

                if (question.StartsWith('#'))
                {
                    if (NumberSurveyTokens > 0)
                    {
                        DiscardNumberSurveyToken();
                        ColorConsole.WriteEmbeddedColor($"[Yellow]{ScenarioBoard.ConvertQuestionToHumanReading(question)}[/Yellow] {Question(question)}", true);
                        return;
                    }
                    else
                    {
                        questionsAvailable.Remove(question);
                        TurnIA(questionsAvailable);
                        return;
                    }
                }
                else
                {
                    if (CardSurveyTokens > 0)
                    {
                        DiscardCardSurveyToken();
                        ColorConsole.WriteEmbeddedColor($"[Yellow]{ScenarioBoard.ConvertQuestionToHumanReading(question)}[/Yellow] {Question(question)}", true);
                        return;
                    }
                    else
                    {
                        questionsAvailable.Remove(question);
                        TurnIA(questionsAvailable);
                        return;
                    }
                }
            }
            catch (QuestionException)
            {
                questionsAvailable.Remove(question);
                TurnIA(questionsAvailable);
                return;
            }
        }

        public string ReadQuestion()
        {
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.Write("Je n'ai pas compris votre question ! ");
                return ReadQuestion();
            }

            var question = input.ToUpperInvariant();
            if (!IsQuestionValid(question))
            {
                Console.Write("Je n'ai pas compris votre question ! ");
                return ReadQuestion();
            }

            if (!ScenarioBoard.CheckIsLocationAvailable(question))
            {
                Console.Write("Vous avez déjà utilisé cet emplacement ! ");
                return ReadQuestion();
            }

            if (question.StartsWith('#') && NumberSurveyTokens > 0)
            {
                DiscardNumberSurveyToken();
                return question;
            }
            else if (CardSurveyTokens > 0)
            {
                DiscardCardSurveyToken();
                return question;
            }

            Console.Write("Vous n'avez plus assez de jeton pour cette question ! ");
            return ReadQuestion();
        }

        protected void InternalLaunch()
        {
            while (TotalSurveyTokens != 0)
            {
                Console.WriteLine("---- JOUEUR ----");
                Console.Write("Qu'elle est votre question ? ");
                var question = ReadQuestion();
                ColorConsole.WriteEmbeddedColor($"Votre indice : {Question(question)} [Appuyez sur Entrée]");
                Console.Read();
                Console.WriteLine();

                if (TotalSurveyTokens > 0 && IsIAEnabled)
                {
                    Console.WriteLine("---- IA ----");
                    TurnIA(ScenarioBoard.Questions);

                    Console.WriteLine();
                }
            }

            SolvingCombinations();
        }

        protected void ReadCombination(List<BaseCard> cards, BaseCard solution, string question)
        {
            ColorConsole.WriteEmbeddedColor(question);
            var card = Console.ReadLine();

            if (string.IsNullOrEmpty(card))
            {
                Console.WriteLine("Veuillez indiquer une réponse !");
                ReadCombination(cards, solution, question);
                return;
            }

            card = card.Trim().RemoveDiacritics().ToLowerInvariant();

            var count = cards.Where(c => c.ConvertNameToSearch().Equals(card, StringComparison.InvariantCultureIgnoreCase)).Count();
            if (count != 1)
            {
                Console.WriteLine("Je ne connais pas la carte !");
                ReadCombination(cards, solution, question);
                return;
            }

            if (card.Equals(solution.ConvertNameToSearch(), StringComparison.InvariantCultureIgnoreCase))
                return;
            else
            {
                if (AlmostInnocentTokens > 0)
                {
                    DiscardAlmostInnocentToken();

                    ColorConsole.WriteLine("Votre réponse est fausse !", ConsoleColor.Red);
                    ReadCombination(cards, solution, question);
                    return;
                }
                else
                    throw new LostGameException();
            }
        }

        protected static DIFFICULTY_LEVEL SetDifficultyLevel()
        {
            var level = Console.ReadLine();
            if (string.IsNullOrEmpty(level) || !_regexDifficultyLevel.IsMatch(level) || !int.TryParse(level, out var result))
            {
                Console.Write("Je ne comprends pas votre choix ! ");
                return SetDifficultyLevel();
            }

            return (DIFFICULTY_LEVEL)result;
        }

        protected static bool SetIA()
        {
            var isEnabled = Console.ReadLine();
            if (string.IsNullOrEmpty(isEnabled) || !_regexIA.IsMatch(isEnabled))
            {
                Console.Write("Je ne comprends pas votre choix ! ");
                return SetIA();
            }

            if (isEnabled.ToUpperInvariant() == "O")
                return true;
            else
                return false;
        }

        protected abstract string Question(string question);

        protected abstract void SolvingCombinations();

        protected static string BuildHistory(List<BaseCard> cards)
        {
            var sb = new StringBuilder();

            if (cards.FirstOrDefault(c => c is GuiltyCard) is GuiltyCard guilty)
                sb.Append($" {guilty.Text} ");

            if (cards.FirstOrDefault(c => c is CrimeCard) is CrimeCard crime)
                sb.Append($" {crime.Text} ");

            if (cards.FirstOrDefault(c => c is VictimCard) is VictimCard victim)
                sb.Append($" {victim.Text} ");

            if (cards.FirstOrDefault(c => c is PlaceCard) is PlaceCard place)
                sb.Append($" {place.Text} ");

            if (cards.FirstOrDefault(c => c is EvidenceCard) is EvidenceCard evidence)
                sb.Append($" {evidence.Text} ");

            return Regex.Replace(sb.ToString(), @"\s+", " ", RegexOptions.Singleline).Trim();
        }

        private bool IsQuestionValid(string question)
            => _regexQuestion.IsMatch(question);
    }
}


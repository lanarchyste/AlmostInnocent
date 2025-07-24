using Almost_Innocent.Cards;
using Almost_Innocent.Characters;
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
        private readonly Regex? _regexCapacity;
        private static readonly Regex _regexDifficultyLevel = new("^[1-3]$");
        private static readonly Regex _regexYesOrNo = new("^(O|o|N|n)$");
        private bool _capacityAlreadyActivated = false;

        public BaseScenario(BaseBoard scenarioBoard, List<CardType> cardTypes, Regex regexQuestion, Regex? regexCapacity, bool isAIEnabled, bool isGameStartWithClues, int totalSurveyTokens, int numberSurveyTokens, int cardSurveyTokens, int almostInnocentTokens)
        {
            ScenarioBoard = scenarioBoard;
            CardTypes = cardTypes;
            IsAIEnabled = isAIEnabled;
            IsGameStartWithClues = isGameStartWithClues;
            TotalSurveyTokens = totalSurveyTokens;
            NumberSurveyTokens = numberSurveyTokens;
            CardSurveyTokens = cardSurveyTokens;
            AlmostInnocentTokens = almostInnocentTokens;

            _regexQuestion = regexQuestion;
            _regexCapacity = regexCapacity;
        }

        public BaseBoard ScenarioBoard { get; private set; }

        public List<CardType> CardTypes { get; }

        public bool IsAIEnabled { get; private set; }

        public bool IsGameStartWithClues { get; private set; }

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
            => AlmostInnocentTokens -= 1;

        public void TurnIA(List<string> questionsAvailable)
        {
            if (!questionsAvailable.Any())
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

                if ((mustUseNumberSurveyToken && question.StartsWith('#')) || (!mustUseNumberSurveyToken && !question.StartsWith('#')))
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

            var question = input.Trim().RemoveDiacritics().ToUpperInvariant();
            var isQuestionValid = IsQuestionValid(question);
            var isCapacityValid = IsCapacityValid(question);

            if ((!isQuestionValid && !isCapacityValid) || (isQuestionValid && isCapacityValid))
            {
                Console.Write("Je n'ai pas compris votre question ! ");
                return ReadQuestion();
            }

            if (isQuestionValid)
            {
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
            else if (isCapacityValid)
            {
                if (_capacityAlreadyActivated)
                {
                    Console.Write("Vous avez déjà activé votre capacité ! ");
                    return ReadQuestion();
                }

                _capacityAlreadyActivated = true;
                return UseCapacity(question);
            }

            return ReadQuestion();
        }

        protected void InternalLaunch()
        {
            if (IsGameStartWithClues)
            {
                Console.WriteLine("Voici vos indices de départ :");

                foreach (var cardType in CardTypes)
                {
                    switch (cardType)
                    {
                        case CardType.Guilty:
                            var guiltyCard = GuiltyCard.Random();
                            var guiltyPosition = ScenarioBoard.GetPosition(guiltyCard);
                            ColorConsole.WriteEmbeddedColor($"\tÉliminer le [Gray]coupable {guiltyCard.Name.Replace('_', ' ').ToUpperInvariant()}[/Gray] ({guiltyPosition})", true);
                            break;

                        case CardType.Crime:
                            var crimeCard = CrimeCard.Random();
                            var crimePosition = ScenarioBoard.GetPosition(crimeCard);
                            ColorConsole.WriteEmbeddedColor($"\tÉliminer le [Yellow]crime {crimeCard.Name.Replace('_', ' ').ToUpperInvariant()}[/Yellow] ({crimePosition})", true);
                            break;

                        case CardType.Victim:
                            var victimCard = VictimCard.Random();
                            var victimPosition = ScenarioBoard.GetPosition(victimCard);
                            ColorConsole.WriteEmbeddedColor($"\tÉliminer la [Blue]victime {victimCard.Name.Replace('_', ' ').ToUpperInvariant()}[/Blue] ({victimPosition})", true);
                            break;

                        case CardType.Place:
                            var placeCard = PlaceCard.Random();
                            var placePosition = ScenarioBoard.GetPosition(placeCard);
                            ColorConsole.WriteEmbeddedColor($"\tÉliminer le [DarkYellow]lieu {placeCard.Name.Replace('_', ' ').ToUpperInvariant()}[/DarkYellow] ({placePosition})", true);
                            break;

                        case CardType.Evidence:
                            var evidenceCard = EvidenceCard.Random();
                            var evidencePosition = ScenarioBoard.GetPosition(evidenceCard);
                            ColorConsole.WriteEmbeddedColor($"\tÉliminer la [Green]preuve {evidenceCard.Name.Replace('_', ' ').ToUpperInvariant()}[/Green] ({evidencePosition})", true);
                            break;
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Appuyer sur une touche dès que vous êtes prêt pour commencer la partie !");
                Console.ReadKey();
                Console.WriteLine();
            }

            while (TotalSurveyTokens != 0)
            {
                Console.WriteLine("---- JOUEUR ----");
                Console.Write("Qu'elle est votre question ? ");
                var question = ReadQuestion();
                if (!string.IsNullOrEmpty(question))
                {
                    ColorConsole.WriteEmbeddedColor($"Votre indice : {Question(question)} [Appuyez sur Entrée]");
                    Console.Read();
                    Console.WriteLine();
                }

                if (TotalSurveyTokens > 0 && IsAIEnabled)
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

        protected static bool SetYesOrNo()
        {
            var isEnabled = Console.ReadLine();
            if (string.IsNullOrEmpty(isEnabled) || !_regexYesOrNo.IsMatch(isEnabled))
            {
                Console.Write("Je ne comprends pas votre choix ! ");
                return SetYesOrNo();
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

        private string UseCapacity(string characterName)
        {
            switch (characterName)
            {
                case "DIN":
                    DinCharacter.UseCapacity(ScenarioBoard, CardTypes);
                    break;

                case "TEOR":
                    break;

                case "EDD":
                    break;

                case "OKRA":
                    break;

                case "VALIA":
                    break;

                default:
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Appuyer sur une touche dès que vous êtes prêt à continuer !");
            Console.ReadKey();
            Console.WriteLine();

            return string.Empty;
        }

        private bool IsQuestionValid(string question)
            => _regexQuestion.IsMatch(question);

        private bool IsCapacityValid(string question)
            => _regexCapacity != null && _regexCapacity.IsMatch(question);
    }
}


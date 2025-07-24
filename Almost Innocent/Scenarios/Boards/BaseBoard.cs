using Almost_Innocent.Cards;
using Almost_Innocent.Scenarios.Exceptions;

namespace Almost_Innocent.Scenarios.Boards
{
    public abstract class BaseBoard(BaseCard[,] board)
    {
        private readonly List<string> _locationUnavailable = [];

        private BaseCard[,] Board { get; } = board;

        private List<string> CommonQuestions
            => ["#1", "#2", "#3", "#4", "#5", "#6", "#A", "#B", "#C", "#D", "#E", "#F"];

        public bool CheckIsLocationAvailable(string question)
        => question switch
        {
            "#1" or "V1" or "VICTIME 1" or "BLEU 1" or "P1" or "PREUVE 1" or "VERT 1" or "L1" or "LIEU 1" or "ORANGE 1" or "CR1" or "CRIME 1" or "JAUNE 1" or "CO1" or "COUPABLE 1" or "NOIR 1" => IsLocationAvailable("1"),
            "#2" or "V2" or "VICTIME 2" or "BLEU 2" or "P2" or "PREUVE 2" or "VERT 2" or "L2" or "LIEU 2" or "ORANGE 2" or "CR2" or "CRIME 2" or "JAUNE 2" or "CO2" or "COUPABLE 2" or "NOIR 2" => IsLocationAvailable("2"),
            "#3" or "V3" or "VICTIME 3" or "BLEU 3" or "P3" or "PREUVE 3" or "VERT 3" or "L3" or "LIEU 3" or "ORANGE 3" or "CR3" or "CRIME 3" or "JAUNE 3" or "CO3" or "COUPABLE 3" or "NOIR 3" => IsLocationAvailable("3"),
            "#4" or "V4" or "VICTIME 4" or "BLEU 4" or "P4" or "PREUVE 4" or "VERT 4" or "L4" or "LIEU 4" or "ORANGE 4" or "CR4" or "CRIME 4" or "JAUNE 4" or "CO4" or "COUPABLE 4" or "NOIR 4" => IsLocationAvailable("4"),
            "#5" or "V5" or "VICTIME 5" or "BLEU 5" or "P5" or "PREUVE 5" or "VERT 5" or "L5" or "LIEU 5" or "ORANGE 5" or "CR5" or "CRIME 5" or "JAUNE 5" or "CO5" or "COUPABLE 5" or "NOIR 5" => IsLocationAvailable("5"),
            "#6" or "V6" or "VICTIME 6" or "BLEU 6" or "P6" or "PREUVE 6" or "VERT 6" or "L6" or "LIEU 6" or "ORANGE 6" or "CR6" or "CRIME 6" or "JAUNE 6" or "CO6" or "COUPABLE 6" or "NOIR 6" => IsLocationAvailable("6"),
            "#A" or "VA" or "VICTIME A" or "BLEU A" or "PA" or "PREUVE A" or "VERT A" or "LA" or "LIEU A" or "ORANGE A" or "CRA" or "CRIME A" or "JAUNE A" or "COA" or "COUPABLE A" or "NOIR A" => IsLocationAvailable("A"),
            "#B" or "VB" or "VICTIME B" or "BLEU B" or "PB" or "PREUVE B" or "VERT B" or "LB" or "LIEU B" or "ORANGE B" or "CRB" or "CRIME B" or "JAUNE B" or "COB" or "COUPABLE B" or "NOIR B" => IsLocationAvailable("B"),
            "#C" or "VC" or "VICTIME C" or "BLEU C" or "PC" or "PREUVE C" or "VERT C" or "LC" or "LIEU C" or "ORANGE C" or "CRC" or "CRIME C" or "JAUNE C" or "COC" or "COUPABLE C" or "NOIR C" => IsLocationAvailable("C"),
            "#D" or "VD" or "VICTIME D" or "BLEU D" or "PD" or "PREUVE D" or "VERT D" or "LD" or "LIEU D" or "ORANGE D" or "CRD" or "CRIME D" or "JAUNE D" or "COD" or "COUPABLE D" or "NOIR D" => IsLocationAvailable("D"),
            "#E" or "VE" or "VICTIME E" or "BLEU E" or "PE" or "PREUVE E" or "VERT E" or "LE" or "LIEU E" or "ORANGE E" or "CRE" or "CRIME E" or "JAUNE E" or "COE" or "COUPABLE E" or "NOIR E" => IsLocationAvailable("E"),
            "#F" or "VF" or "VICTIME F" or "BLEU F" or "PF" or "PREUVE F" or "VERT F" or "LF" or "LIEU F" or "ORANGE F" or "CRF" or "CRIME F" or "JAUNE F" or "COF" or "COUPABLE F" or "NOIR F" => IsLocationAvailable("F"),
            _ => false,
        };

        public string Question(string question, List<BaseCard> cards)
            => question switch
            {
                "#1" => GetNumberByRow(cards, 0),
                "#2" => GetNumberByRow(cards, 1),
                "#3" => GetNumberByRow(cards, 2),
                "#4" => GetNumberByRow(cards, 3),
                "#5" => GetNumberByRow(cards, 4),
                "#6" => GetNumberByRow(cards, 5),
                "#A" => GetNumberByColumn(cards, 0),
                "#B" => GetNumberByColumn(cards, 1),
                "#C" => GetNumberByColumn(cards, 2),
                "#D" => GetNumberByColumn(cards, 3),
                "#E" => GetNumberByColumn(cards, 4),
                "#F" => GetNumberByColumn(cards, 5),
                "V1" or "VICTIME 1" or "BLEU 1" => SearchCardByRow<VictimCard>(cards, 0),
                "V2" or "VICTIME 2" or "BLEU 2" => SearchCardByRow<VictimCard>(cards, 1),
                "V3" or "VICTIME 3" or "BLEU 3" => SearchCardByRow<VictimCard>(cards, 2),
                "V4" or "VICTIME 4" or "BLEU 4" => SearchCardByRow<VictimCard>(cards, 3),
                "V5" or "VICTIME 5" or "BLEU 5" => SearchCardByRow<VictimCard>(cards, 4),
                "V6" or "VICTIME 6" or "BLEU 6" => SearchCardByRow<VictimCard>(cards, 5),
                "VA" or "VICTIME A" or "BLEU A" => SearchCardByColumn<VictimCard>(cards, 0),
                "VB" or "VICTIME B" or "BLEU B" => SearchCardByColumn<VictimCard>(cards, 1),
                "VC" or "VICTIME C" or "BLEU C" => SearchCardByColumn<VictimCard>(cards, 2),
                "VD" or "VICTIME D" or "BLEU D" => SearchCardByColumn<VictimCard>(cards, 3),
                "VE" or "VICTIME E" or "BLEU E" => SearchCardByColumn<VictimCard>(cards, 4),
                "VF" or "VICTIME F" or "BLEU F" => SearchCardByColumn<VictimCard>(cards, 5),
                "P1" or "PREUVE 1" or "VERT 1" => SearchCardByRow<EvidenceCard>(cards, 0),
                "P2" or "PREUVE 2" or "VERT 2" => SearchCardByRow<EvidenceCard>(cards, 1),
                "P3" or "PREUVE 3" or "VERT 3" => SearchCardByRow<EvidenceCard>(cards, 2),
                "P4" or "PREUVE 4" or "VERT 4" => SearchCardByRow<EvidenceCard>(cards, 3),
                "P5" or "PREUVE 5" or "VERT 5" => SearchCardByRow<EvidenceCard>(cards, 4),
                "P6" or "PREUVE 6" or "VERT 6" => SearchCardByRow<EvidenceCard>(cards, 5),
                "PA" or "PREUVE A" or "VERT A" => SearchCardByColumn<EvidenceCard>(cards, 0),
                "PB" or "PREUVE B" or "VERT B" => SearchCardByColumn<EvidenceCard>(cards, 1),
                "PC" or "PREUVE C" or "VERT C" => SearchCardByColumn<EvidenceCard>(cards, 2),
                "PD" or "PREUVE D" or "VERT D" => SearchCardByColumn<EvidenceCard>(cards, 3),
                "PE" or "PREUVE E" or "VERT E" => SearchCardByColumn<EvidenceCard>(cards, 4),
                "PF" or "PREUVE F" or "VERT F" => SearchCardByColumn<EvidenceCard>(cards, 5),
                "L1" or "LIEU 1" or "ORANGE 1" => SearchCardByRow<PlaceCard>(cards, 0),
                "L2" or "LIEU 2" or "ORANGE 2" => SearchCardByRow<PlaceCard>(cards, 1),
                "L3" or "LIEU 3" or "ORANGE 3" => SearchCardByRow<PlaceCard>(cards, 2),
                "L4" or "LIEU 4" or "ORANGE 4" => SearchCardByRow<PlaceCard>(cards, 3),
                "L5" or "LIEU 5" or "ORANGE 5" => SearchCardByRow<PlaceCard>(cards, 4),
                "L6" or "LIEU 6" or "ORANGE 6" => SearchCardByRow<PlaceCard>(cards, 5),
                "LA" or "LIEU A" or "ORANGE A" => SearchCardByColumn<PlaceCard>(cards, 0),
                "LB" or "LIEU B" or "ORANGE B" => SearchCardByColumn<PlaceCard>(cards, 1),
                "LC" or "LIEU C" or "ORANGE C" => SearchCardByColumn<PlaceCard>(cards, 2),
                "LD" or "LIEU D" or "ORANGE D" => SearchCardByColumn<PlaceCard>(cards, 3),
                "LE" or "LIEU E" or "ORANGE E" => SearchCardByColumn<PlaceCard>(cards, 4),
                "LF" or "LIEU F" or "ORANGE F" => SearchCardByColumn<PlaceCard>(cards, 5),
                "CR1" or "CRIME 1" or "JAUNE 1" => SearchCardByRow<CrimeCard>(cards, 0),
                "CR2" or "CRIME 2" or "JAUNE 2" => SearchCardByRow<CrimeCard>(cards, 1),
                "CR3" or "CRIME 3" or "JAUNE 3" => SearchCardByRow<CrimeCard>(cards, 2),
                "CR4" or "CRIME 4" or "JAUNE 4" => SearchCardByRow<CrimeCard>(cards, 3),
                "CR5" or "CRIME 5" or "JAUNE 5" => SearchCardByRow<CrimeCard>(cards, 4),
                "CR6" or "CRIME 6" or "JAUNE 6" => SearchCardByRow<CrimeCard>(cards, 5),
                "CRA" or "CRIME A" or "JAUNE A" => SearchCardByColumn<CrimeCard>(cards, 0),
                "CRB" or "CRIME B" or "JAUNE B" => SearchCardByColumn<CrimeCard>(cards, 1),
                "CRC" or "CRIME C" or "JAUNE C" => SearchCardByColumn<CrimeCard>(cards, 2),
                "CRD" or "CRIME D" or "JAUNE D" => SearchCardByColumn<CrimeCard>(cards, 3),
                "CRE" or "CRIME E" or "JAUNE E" => SearchCardByColumn<CrimeCard>(cards, 4),
                "CRF" or "CRIME F" or "JAUNE F" => SearchCardByColumn<CrimeCard>(cards, 5),
                "CO1" or "COUPABLE 1" or "NOIR 1" => SearchCardByRow<GuiltyCard>(cards, 0),
                "CO2" or "COUPABLE 2" or "NOIR 2" => SearchCardByRow<GuiltyCard>(cards, 1),
                "CO3" or "COUPABLE 3" or "NOIR 3" => SearchCardByRow<GuiltyCard>(cards, 2),
                "CO4" or "COUPABLE 4" or "NOIR 4" => SearchCardByRow<GuiltyCard>(cards, 3),
                "CO5" or "COUPABLE 5" or "NOIR 5" => SearchCardByRow<GuiltyCard>(cards, 4),
                "CO6" or "COUPABLE 6" or "NOIR 6" => SearchCardByRow<GuiltyCard>(cards, 5),
                "COA" or "COUPABLE A" or "NOIR A" => SearchCardByColumn<GuiltyCard>(cards, 0),
                "COB" or "COUPABLE B" or "NOIR B" => SearchCardByColumn<GuiltyCard>(cards, 1),
                "COC" or "COUPABLE C" or "NOIR C" => SearchCardByColumn<GuiltyCard>(cards, 2),
                "COD" or "COUPABLE D" or "NOIR D" => SearchCardByColumn<GuiltyCard>(cards, 3),
                "COE" or "COUPABLE E" or "NOIR E" => SearchCardByColumn<GuiltyCard>(cards, 4),
                "COF" or "COUPABLE F" or "NOIR F" => SearchCardByColumn<GuiltyCard>(cards, 5),
                _ => "-",
            };

        public static string ConvertQuestionToHumanReading(string question)
            => question switch
            {
                "#1" => "Combien d'indices vous concerne dans la ligne 1 ?",
                "#2" => "Combien d'indices vous concerne dans la ligne 2 ?",
                "#3" => "Combien d'indices vous concerne dans la ligne 3 ?",
                "#4" => "Combien d'indices vous concerne dans la ligne 4 ?",
                "#5" => "Combien d'indices vous concerne dans la ligne 5 ?",
                "#6" => "Combien d'indices vous concerne dans la ligne 6 ?",
                "#A" => "Combien d'indices vous concerne dans la colonne A ?",
                "#B" => "Combien d'indices vous concerne dans la colonne B ?",
                "#C" => "Combien d'indices vous concerne dans la colonne C ?",
                "#D" => "Combien d'indices vous concerne dans la colonne D ?",
                "#E" => "Combien d'indices vous concerne dans la colonne E ?",
                "#F" => "Combien d'indices vous concerne dans la colonne F ?",
                "V1" => "Est-ce que votre victime se trouve dans la ligne 1 ?",
                "V2" => "Est-ce que votre victime se trouve dans la ligne 2 ?",
                "V3" => "Est-ce que votre victime se trouve dans la ligne 3 ?",
                "V4" => "Est-ce que votre victime se trouve dans la ligne 4 ?",
                "V5" => "Est-ce que votre victime se trouve dans la ligne 5 ?",
                "V6" => "Est-ce que votre victime se trouve dans la ligne 6 ?",
                "VA" => "Est-ce que votre victime se trouve dans la colonne A ?",
                "VB" => "Est-ce que votre victime se trouve dans la colonne B ?",
                "VC" => "Est-ce que votre victime se trouve dans la colonne C ?",
                "VD" => "Est-ce que votre victime se trouve dans la colonne D ?",
                "VE" => "Est-ce que votre victime se trouve dans la colonne E ?",
                "VF" => "Est-ce que votre victime se trouve dans la colonne F ?",
                "P1" => "Est-ce que votre preuve se trouve dans la ligne 1 ?",
                "P2" => "Est-ce que votre preuve se trouve dans la ligne 2 ?",
                "P3" => "Est-ce que votre preuve se trouve dans la ligne 3 ?",
                "P4" => "Est-ce que votre preuve se trouve dans la ligne 4 ?",
                "P5" => "Est-ce que votre preuve se trouve dans la ligne 5 ?",
                "P6" => "Est-ce que votre preuve se trouve dans la ligne 6 ?",
                "PA" => "Est-ce que votre preuve se trouve dans la colonne A ?",
                "PB" => "Est-ce que votre preuve se trouve dans la colonne B ?",
                "PC" => "Est-ce que votre preuve se trouve dans la colonne C ?",
                "PD" => "Est-ce que votre preuve se trouve dans la colonne D ?",
                "PE" => "Est-ce que votre preuve se trouve dans la colonne E ?",
                "PF" => "Est-ce que votre preuve se trouve dans la colonne F ?",
                "L1" => "Est-ce que votre lieu se trouve dans la ligne 1 ?",
                "L2" => "Est-ce que votre lieu se trouve dans la ligne 2 ?",
                "L3" => "Est-ce que votre lieu se trouve dans la ligne 3 ?",
                "L4" => "Est-ce que votre lieu se trouve dans la ligne 4 ?",
                "L5" => "Est-ce que votre lieu se trouve dans la ligne 5 ?",
                "L6" => "Est-ce que votre lieu se trouve dans la ligne 6 ?",
                "LA" => "Est-ce que votre lieu se trouve dans la colonne A ?",
                "LB" => "Est-ce que votre lieu se trouve dans la colonne B ?",
                "LC" => "Est-ce que votre lieu se trouve dans la colonne C ?",
                "LD" => "Est-ce que votre lieu se trouve dans la colonne D ?",
                "LE" => "Est-ce que votre lieu se trouve dans la colonne E ?",
                "LF" => "Est-ce que votre lieu se trouve dans la colonne F ?",
                "CR1" => "Est-ce que votre crime se trouve dans la ligne 1 ?",
                "CR2" => "Est-ce que votre crime se trouve dans la ligne 2 ?",
                "CR3" => "Est-ce que votre crime se trouve dans la ligne 3 ?",
                "CR4" => "Est-ce que votre crime se trouve dans la ligne 4 ?",
                "CR5" => "Est-ce que votre crime se trouve dans la ligne 5 ?",
                "CR6" => "Est-ce que votre crime se trouve dans la ligne 6 ?",
                "CRA" => "Est-ce que votre crime se trouve dans la colonne A ?",
                "CRB" => "Est-ce que votre crime se trouve dans la colonne B ?",
                "CRC" => "Est-ce que votre crime se trouve dans la colonne C ?",
                "CRD" => "Est-ce que votre crime se trouve dans la colonne D ?",
                "CRE" => "Est-ce que votre crime se trouve dans la colonne E ?",
                "CRF" => "Est-ce que votre crime se trouve dans la colonne F ?",
                "CO1" => "Est-ce que votre coupable se trouve dans la ligne 1 ?",
                "CO2" => "Est-ce que votre coupable se trouve dans la ligne 2 ?",
                "CO3" => "Est-ce que votre coupable se trouve dans la ligne 3 ?",
                "CO4" => "Est-ce que votre coupable se trouve dans la ligne 4 ?",
                "CO5" => "Est-ce que votre coupable se trouve dans la ligne 5 ?",
                "CO6" => "Est-ce que votre coupable se trouve dans la ligne 6 ?",
                "COA" => "Est-ce que votre coupable se trouve dans la colonne A ?",
                "COB" => "Est-ce que votre coupable se trouve dans la colonne B ?",
                "COC" => "Est-ce que votre coupable se trouve dans la colonne C ?",
                "COD" => "Est-ce que votre coupable se trouve dans la colonne D ?",
                "COE" => "Est-ce que votre coupable se trouve dans la colonne E ?",
                "COF" => "Est-ce que votre coupable se trouve dans la colonne F ?",
                _ => "-",
            };

        public List<string> Questions
            => CommonQuestions.Concat(BuildQuestionsRelatedToScenario()).ToList();

        public string GetPosition(BaseCard card)
        {
            for (var row = 0; row < Board.GetLength(0); row++)
                for (var column = 0; column < Board.GetLength(1); column++)
                    if (Board[row, column].Name == card.Name)
                    {
                        var position = ConvertColumnIndexToPosition(column + 1);
                        if (string.IsNullOrEmpty(position))
                            return string.Empty;

                        return $"{position}{row + 1}";
                    }

            return string.Empty;
        }

        private List<string> BuildQuestionsRelatedToScenario()
        {
            var questions = new List<string>();

            for (var row = 0; row < Board.GetLength(0); row++)
                for (var column = 0; column < Board.GetLength(1); column++)
                {
                    var card = Board[row, column];

                    questions.Add(BuildQuestionByRow(card, row + 1));
                    questions.Add(BuildQuestionByColumn(card, column + 1));
                }

            return [.. questions.Where(x => !string.IsNullOrEmpty(x)).Distinct()];
        }

        private static string BuildQuestionByRow(BaseCard card, int row)
            => card switch
            {
                CrimeCard => $"CR{row}",
                EvidenceCard => $"P{row}",
                GuiltyCard => $"CO{row}",
                PlaceCard => $"L{row}",
                VictimCard => $"V{row}",
                _ => string.Empty,
            };

        private static string BuildQuestionByColumn(BaseCard card, int column)
        {
            var position = ConvertColumnIndexToPosition(column);
            if (string.IsNullOrEmpty(position))
                return string.Empty;

            return card switch
            {
                CrimeCard => $"CR{position}",
                EvidenceCard => $"P{position}",
                GuiltyCard => $"CO{position}",
                PlaceCard => $"L{position}",
                VictimCard => $"V{position}",
                _ => string.Empty,
            };
        }

        private static string ConvertColumnIndexToPosition(int column)
            => column switch
            {
                1 => "A",
                2 => "B",
                3 => "C",
                4 => "D",
                5 => "E",
                6 => "F",
                _ => string.Empty,
            };

        private string GetNumberByRow(List<BaseCard> cards, int rowNumber)
        {
            if (UseRow(rowNumber))
            {
                var count = GetRow(rowNumber).Where(r => cards.Select(c => c.Name).Contains(r.Name)).Count();
                if (count > 0)
                    return $"[Green]{count}[/Green]";
                else
                    return $"[Red]{count}[/Red]";
            }
            else
                return "-";
        }

        private string GetNumberByColumn(List<BaseCard> cards, int columnNumber)
        {
            if (UseColumn(columnNumber))
            {
                var count = GetColumn(columnNumber).Where(r => cards.Select(c => c.Name).Contains(r.Name)).Count();
                if (count > 0)
                    return $"[Green]{count}[/Green]";
                else
                    return $"[Red]{count}[/Red]";
            }
            else
                return "-";
        }

        private string SearchCardByRow<T>(List<BaseCard> cards, int rowNumber)
        {
            if (UseRow(rowNumber))
            {
                var card = cards.Find(c => c is T);
                if (card == null)
                    throw new QuestionException();
                else
                    return GetRow(rowNumber).FirstOrDefault(r => card.Name.Equals(r.Name)) == null ? "[Red]Non[/Red]" : "[Green]Oui[/Green]";
            }
            else
                return "-";
        }

        private string SearchCardByColumn<T>(List<BaseCard> cards, int columnNumber)
        {
            if (UseColumn(columnNumber))
            {
                var card = cards.Find(c => c is T);
                if (card == null)
                    throw new QuestionException();
                else
                    return GetColumn(columnNumber).FirstOrDefault(r => card.Name.Equals(r.Name)) == null ? "[Red]Non[/Red]" : "[Green]Oui[/Green]";
            }
            else
                return "-";
        }

        private bool UseRow(int row)
            => row switch
            {
                0 => UseLocation("1"),
                1 => UseLocation("2"),
                2 => UseLocation("3"),
                3 => UseLocation("4"),
                4 => UseLocation("5"),
                5 => UseLocation("6"),
                _ => throw new QuestionException(),
            };

        private bool UseColumn(int column)
            => column switch
            {
                0 => UseLocation("A"),
                1 => UseLocation("B"),
                2 => UseLocation("C"),
                3 => UseLocation("D"),
                4 => UseLocation("E"),
                5 => UseLocation("F"),
                _ => throw new QuestionException(),
            };

        private bool IsLocationAvailable(string location)
            => !_locationUnavailable.Contains(location);

        private bool UseLocation(string location)
        {
            if (!IsLocationAvailable(location))
                return false;

            _locationUnavailable.Add(location);
            return true;
        }

        private BaseCard[] GetCardsByRow(int row)
            => [.. Enumerable.Range(0, Board.GetLength(1)).Select(column => Board[row, column])];

        private BaseCard[] GetCardsByColumn(int column)
            => [.. Enumerable.Range(0, Board.GetLength(0)).Select(row => Board[row, column])];
    }
}


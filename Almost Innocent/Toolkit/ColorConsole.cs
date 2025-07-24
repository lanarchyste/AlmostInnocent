using System.Text.RegularExpressions;

namespace Almost_Innocent.Toolkit
{
    public static class ColorConsole
    {
        public static void WriteLine(string text, ConsoleColor? color = null)
        {
            if (color.HasValue)
            {
                var oldColor = Console.ForegroundColor;
                if (color == oldColor)
                    Console.WriteLine(text);
                else
                {
                    Console.ForegroundColor = color.Value;
                    Console.WriteLine(text);
                    Console.ForegroundColor = oldColor;
                }
            }
            else
                Console.WriteLine(text);
        }

        public static void WriteLine(string text, string color)
        {
            if (string.IsNullOrEmpty(color))
            {
                WriteLine(text);
                return;
            }

            if (!Enum.TryParse(color, true, out ConsoleColor col))
                WriteLine(text);
            else
                WriteLine(text, col);
        }

        public static void Write(string text, ConsoleColor? color = null)
        {
            if (color.HasValue)
            {
                var oldColor = Console.ForegroundColor;
                if (color == oldColor)
                    Console.Write(text);
                else
                {
                    Console.ForegroundColor = color.Value;
                    Console.Write(text);
                    Console.ForegroundColor = oldColor;
                }
            }
            else
                Console.Write(text);
        }

        public static void Write(string text, string color)
        {
            if (string.IsNullOrEmpty(color))
            {
                Write(text);
                return;
            }

            if (!Enum.TryParse(color, true, out ConsoleColor col))
                Write(text);
            else
                Write(text, col);
        }

        public static void WriteEmbeddedColor(string text, bool addLine = false, ConsoleColor? baseTextColor = null)
        {
            baseTextColor ??= Console.ForegroundColor;

            if (string.IsNullOrEmpty(text))
            {
                if (addLine)
                    WriteLine(string.Empty);
                else
                    Write(string.Empty);
                return;
            }

            int at = text.IndexOf("[");
            int at2 = text.IndexOf("]");
            if (at == -1 || at2 <= at)
            {
                if (addLine)
                    WriteLine(text, baseTextColor);
                else
                    Write(text, baseTextColor);
                return;
            }

            while (true)
            {
                var match = colorBlockRegEx.Value.Match(text);
                if (match.Length < 1)
                {
                    Write(text, baseTextColor);
                    break;
                }

                // write up to expression
                Write(text.Substring(0, match.Index), baseTextColor);

                // strip out the expression
                string highlightText = match.Groups["text"].Value;
                string colorVal = match.Groups["color"].Value;

                Write(highlightText, colorVal);

                // remainder of string
                text = text.Substring(match.Index + match.Value.Length);
            }

            if (addLine)
                Console.WriteLine();
        }

        private static Lazy<Regex> colorBlockRegEx = new(() => new Regex("\\[(?<color>.*?)\\](?<text>[^[]*)\\[/\\k<color>\\]", RegexOptions.IgnoreCase), isThreadSafe: true);
    }
}


using Diacritics.Extensions;

namespace Almost_Innocent.Cards
{
    public class BaseCard
	{
		public BaseCard(string name, string text, bool isAdditionalClue)
		{
			Name = name;
			Text = text;
			IsAdditionalClue = isAdditionalClue;
		}

        public string Name { get; }

        public string Text { get; }

        public bool IsAdditionalClue { get; }

		public string ConvertNameToSearch()
			=> Name.Replace('_', ' ').RemoveDiacritics().ToLowerInvariant();
    }
}


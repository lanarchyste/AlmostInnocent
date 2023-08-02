using Diacritics.Extensions;

namespace Almost_Innocent.Cards
{
    public class BaseCard
	{
		public BaseCard(string name, bool isAdditionalClue)
		{
			Name = name;
			IsAdditionalClue = isAdditionalClue;
		}

        public string Name { get; }

		public bool IsAdditionalClue { get; }

		public string ConvertNameToSearch()
			=> Name.Replace('_', ' ').RemoveDiacritics().ToLowerInvariant();
    }
}


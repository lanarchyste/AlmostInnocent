﻿namespace Almost_Innocent.Cards
{
    public class EmptyCard: BaseCard
	{
		public EmptyCard()
			: base(string.Empty, string.Empty, false)
		{
		}

		public static EmptyCard EMPTY => new();
	}
}


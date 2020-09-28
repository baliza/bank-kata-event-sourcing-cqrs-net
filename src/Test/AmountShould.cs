namespace src.Test
{
	using Console.Test;
	using Domain;

	internal static class AmountShould
	{
		internal static void add_two_amount()
		{
			Amount amount1 = Amount.Of(0.0);
			Amount amount2 = Amount.Of(1.0);
			Assert.ThatAreEqual(amount1.Add(amount2), Amount.Of(1.0), "add_two_amount");
		}
	}
}
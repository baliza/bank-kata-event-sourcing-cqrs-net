namespace src.Test
{
	using Console.Test;
	using Domain;

	internal static class AmountShould
	{
		internal static void be_initialize_with_positive_value()
		{
			Amount amount = Amount.Of(0);
			Assert.ThatAreEqual(amount.Value, 0.0, "be_initialize_with_positive_value");
		}

		internal static void add_two_amount()
		{
			Amount amount1 = Amount.Of(0.0);
			Amount amount2 = Amount.Of(2.0);
			Assert.ThatAreEqual(amount1.Add(amount2), Amount.Of(2.0), "add_two_amount");
		}
	}
}
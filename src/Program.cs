namespace src
{
	using Console.Test;
	using src.Test;
	using System;

	public static class Program
	{
		public static void Main(string[] args)
		{
			Terminal.WriteWhite("An honest man is always a child!");

			Terminal.WriteWhite("");
			Terminal.WriteWhite("AccountShould");
			AccountShould.have_a_zero_balance_when_account_created_as_empty();
			AccountShould.have_the_balance_specified_as_input_of_account_creation();
			AccountShould.add_amount_to_empty_account_when_deposit_is_made();
			AccountShould.add_amount_to_non_zero_balance_when_deposit_is_made();
			AccountShould.fail_when_deposit_a_negative_amount();
			AccountShould.fail_when_deposit_a_zero_amount();
			AccountShould.add_creation_event_when_creating_account();

			Terminal.WriteWhite("");
			Terminal.WriteWhite("AmountShould");
			AmountShould.add_two_amount();
			AmountShould.be_initialize_with_positive_value();

			Console.ReadLine();
		}
	}
}
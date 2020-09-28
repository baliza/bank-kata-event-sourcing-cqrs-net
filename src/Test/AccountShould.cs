namespace src.Test
{
	using Console.Test;
	using Domain;
	using Domain.Event;
	using System;
	using System.Collections.Generic;

	internal static class AccountShould
	{
		internal static void have_a_zero_balance_when_account_created_as_empty()
		{
			Account account = Account.Empty();
			Assert.ThatAreEqual(account.Balance, Balance.ZERO, "have_a_zero_balance_when_account_created_as_empty");
		}

		internal static void have_the_balance_specified_as_input_of_account_creation()
		{
			Account account = Account.With(Balance.Of(1.0));
			Assert.ThatAreEqual(account.Balance, Balance.Of(1.0), "have_the_balance_specified_as_input_of_account_creation");
		}

		internal static void add_amount_to_empty_account_when_deposit_is_made()
		{
			Account account = Account.Empty();

			account.Deposit(Amount.Of(10.0));
			Assert.ThatAreEqual(account.Balance, Balance.Of(10.0), "add_amount_to_empty_account_when_deposit_is_made");
		}

		internal static void add_amount_to_non_zero_balance_when_deposit_is_made()
		{
			Account account = Account.With(Balance.Of(10.0));

			account.Deposit(Amount.Of(5.0));

			Assert.ThatAreEqual(account.Balance, Balance.Of(15.0), "add_amount_to_non_zero_balance_when_deposit_is_made");
		}

		internal static void fail_when_deposit_a_zero_amount()
		{
			Account account = Account.Empty();
			try
			{
				account.Deposit(Amount.Of(0.0));
				Terminal.WriteRed("fail_when_deposit_a_zero_amount");
			}
			catch (Exception ex)
			{
				if (ex.Message == "A deposit must be positive")
					Terminal.WriteGreen("fail_when_deposit_a_zero_amount");
				else
					Terminal.WriteRed("fail_when_deposit_a_zero_amount");
			}
		}

		internal static void fail_when_deposit_a_negative_amount()
		{
			Account account = Account.Empty();
			try
			{
				account.Deposit(Amount.Of(-1.0));
				Terminal.WriteRed("fail_when_deposit_a_negative_amount");
			}
			catch (Exception ex)
			{
				if (ex.Message == "A deposit must be positive")
					Terminal.WriteGreen("fail_when_deposit_a_negative_amount");
				else
					Terminal.WriteRed("fail_when_deposit_a_negative_amount");
			}
		}

		internal static void add_creation_event_when_creating_account()
		{
			Account account = Account.Empty();
			Assert.ContainsOnly(account.UncommittedChanges, new NewAccountCreated(account.AccountId, Balance.ZERO), "add_creation_event_when_creating_account");
		}

		internal static void add_deposit_event_to_uncommitted_change_when_deposit_made()
		{
			Account account = Account.Empty();

			account.Deposit(Amount.Of(10.0));

			Assert.Contains(account.UncommittedChanges, new NewDepositMade(account.AccountId, Amount.Of(10.0)), "add_deposit_event_to_uncommitted_change_when_deposit_made");
		}

		internal static void be_initialized_with_past_events()
		{
			AccountId accountId = AccountId.Create();
			var events = new List<IAccountEvent>() { new NewAccountCreated(accountId, Balance.Of(10.0)), new NewDepositMade(accountId, Amount.Of(10.0)) };

			Account account = Account.Rebuild(events);

			Assert.ThatAreEqual(account.Balance, Balance.Of(20.0), "be_initialized_with_past_events-1");
			Assert.ThatAreEqual(account.AccountId, accountId, "be_initialized_with_past_events-2");
		}
	}
}
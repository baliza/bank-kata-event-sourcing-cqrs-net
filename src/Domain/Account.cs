namespace Domain
{
	using Domain.Event;
	using System;
	using System.Collections.Generic;

	public class Account
	{
		private Account(AccountId accountId, Balance balance)
		{
			NewAccountCreated newAccountCreated = new NewAccountCreated(accountId, balance);
			AccountId = newAccountCreated.AccountId;
			Balance = newAccountCreated.Balance;
			UncommittedChanges = new List<IAccountEvent>() { newAccountCreated };
		}

		public AccountId AccountId { get; }
		public Balance Balance { get; private set; }
		public List<IAccountEvent> UncommittedChanges { get; }

		public static Account Empty()
		{
			return new Account(AccountId.Create(), Balance.ZERO);
		}

		public static Account With(Balance balance)
		{
			return new Account(AccountId.Create(), balance);
		}

		public void Deposit(Amount amount)
		{
			Preconditions.CheckArgumentIsTrue(amount.IsPositive, "A deposit must be positive");
			Balance = Balance.Add(amount);
		}

		public override bool Equals(object obj)
		{
			if (this == obj) return true;
			if (obj == null || GetType() != obj.GetType()) return false;

			Account other = (Account)obj;

			return AccountId == other.AccountId && Balance.Equals(other.Balance);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine("Account", AccountId);
		}

		public override string ToString()
		{
			return "Account{" +
				"balance=" + Balance +
				'}';
		}
	}
}
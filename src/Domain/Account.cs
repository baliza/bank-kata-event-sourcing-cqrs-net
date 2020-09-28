namespace Domain
{
	using Domain.Event;
	using System;
	using System.Collections.Generic;

	public class Account
	{
		private Account()
		{
		}

		private Account(AccountId accountId, Balance balance)
		{
			NewAccountCreated newAccountCreated = new NewAccountCreated(accountId, balance);
			AccountId = newAccountCreated.AccountId;
			Balance = newAccountCreated.Balance;
			UncommittedChanges = new List<IAccountEvent>() { newAccountCreated };
		}

		public AccountId AccountId { get; private set; }
		public Balance Balance { get; private set; }
		public List<IAccountEvent> UncommittedChanges { get; private set; }

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
			var newDepositMade = new NewDepositMade(AccountId, amount);
			Apply(newDepositMade);
			SaveUncommittedChange(newDepositMade);
		}

		public static Account Rebuild(List<IAccountEvent> events)
		{
			var account = new Account { UncommittedChanges = new List<IAccountEvent>() };
			foreach (var e in events)
			{
				e.Apply(account);
			}
			return account;
		}

		private void SaveUncommittedChange(IAccountEvent newDepositMade)
		{
			UncommittedChanges.Add(newDepositMade);
		}

		public void Apply(NewDepositMade newDepositMade)
		{
			Balance = Balance.Add(newDepositMade.Amount);
		}

		public void Apply(NewAccountCreated newAccountCreated)
		{
			AccountId = newAccountCreated.AccountId;
			Balance = newAccountCreated.Balance;
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
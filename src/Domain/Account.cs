namespace Domain
{
	using Domain.Event;
	using System;
	using System.Collections.Generic;

	public sealed class Account
	{
		private readonly AccountId _accountId;
		private Balance _balance;

		private Account(AccountId accountId, Balance balance)
		{
			_accountId = accountId;
			_balance = balance;
		}

		public Balance Balance
		{
			get { return _balance; }
		}

		public AccountId AccountId
		{
			get { return _accountId; }
		}

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
			_balance = _balance.Add(amount);
		}

		public List<IAccountEvent> GetUncommittedChanges()
		{
			return new List<IAccountEvent>();
		}

		public override bool Equals(object obj)
		{
			if (this == obj) return true;
			if (obj == null || GetType() != obj.GetType()) return false;

			Account other = (Account)obj;

			return _accountId == other._accountId && _balance.Equals(other._balance);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine("Account", _accountId);
		}

		public override string ToString()
		{
			return "Account{" +
				"balance=" + _balance +
				'}';
		}
	}
}
namespace Domain.Event
{
	using System;

	public class NewAccountCreated : IAccountEvent
	{
		public NewAccountCreated(AccountId accountId, Balance balance)
		{
			AccountId = accountId;
			Balance = balance;
		}

		public AccountId AccountId { get; }

		public Balance Balance { get; }

		public void Apply(Account account)
		{
			account.Apply(this);
		}

		public override bool Equals(object obj)
		{
			if (this == obj) return true;
			if (obj == null || GetType() != obj.GetType()) return false;
			NewAccountCreated that = (NewAccountCreated)obj;
			return AccountId.Equals(that.AccountId) &&
					Balance.Equals(that.Balance);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(AccountId, Balance);
		}

		public override string ToString()
		{
			return "NewAccountCreated{" +
					"accountId=" + AccountId +
					", balance=" + Balance +
					'}';
		}
	}
}
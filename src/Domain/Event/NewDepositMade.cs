namespace Domain.Event
{
	using System;

	public class NewDepositMade : IAccountEvent
	{
		public NewDepositMade(AccountId accountId, Amount amount)
		{
			AccountId = accountId;
			Amount = amount;
		}

		public AccountId AccountId { get; }

		public Amount Amount { get; }

		public override bool Equals(object obj)
		{
			if (this == obj) return true;
			if (obj == null || GetType() != obj.GetType()) return false;
			NewDepositMade that = (NewDepositMade)obj;
			return AccountId.Equals(that.AccountId) &&
					Amount.Equals(that.Amount);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(AccountId, Amount);
		}

		public override string ToString()
		{
			return "NewAccountCreated{" +
					"accountId=" + AccountId +
					", amount=" + Amount +
					'}';
		}
	}
}
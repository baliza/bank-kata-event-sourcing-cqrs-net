namespace Domain.Event
{
	using System;

	public class NewAccountCreated : IAccountEvent
	{
		private readonly AccountId _accountId;
		private readonly Balance _balance;

		public NewAccountCreated(AccountId accountId, Balance balance)
		{
			_accountId = accountId;
			_balance = balance;
		}

		public AccountId AccountId
		{
			get { return _accountId; }
		}

		public Balance Balance
		{
			get { return _balance; }
		}

		public override bool Equals(object obj)
		{
			if (this == obj) return true;
			if (obj == null || GetType() != obj.GetType()) return false;
			NewAccountCreated that = (NewAccountCreated)obj;
			return _accountId.Equals(that._accountId) &&
					_balance.Equals(that._balance);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(_accountId, _balance);
		}

		public override string ToString()
		{
			return "NewAccountCreated{" +
					"accountId=" + _accountId +
					", balance=" + _balance +
					'}';
		}
	}
}
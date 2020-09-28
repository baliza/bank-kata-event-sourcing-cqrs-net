namespace Domain
{
	using System;

	public sealed class AccountId
	{
		private AccountId(Guid id)
		{
			Value = id;
		}

		public Guid Value { get; }

		public static AccountId Create(Guid id)
		{
			return new AccountId(id);
		}

		public static AccountId Create()
		{
			return new AccountId(Guid.NewGuid());
		}

		public override bool Equals(object obj)
		{
			if (this == obj) return true;
			if (obj == null || GetType() != obj.GetType()) return false;

			AccountId other = (AccountId)obj;

			return Value == other.Value;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine("AccountId", Value);
		}

		public override string ToString()
		{
			return "AccountId{" +
					"value=" + Value +
					'}';
		}
	}
}
namespace Domain
{
	using System;

	public sealed class AccountId
	{
		public readonly Guid _id;

		private AccountId(Guid id)
		{
			_id = id;
		}

		public Guid Value
		{
			get { return _id; }
		}

		public static AccountId Create(System.Guid id)
		{
			return new AccountId(id);
		}

		public static AccountId Create()
		{
			return new AccountId(System.Guid.NewGuid());
		}

		public override bool Equals(object obj)
		{
			if (this == obj) return true;
			if (obj == null || GetType() != obj.GetType()) return false;

			AccountId other = (AccountId)obj;

			return _id == other._id;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine("AccountId", _id);
		}

		public override string ToString()
		{
			return "AccountId{" +
					"value=" + _id +
					'}';
		}
	}
}
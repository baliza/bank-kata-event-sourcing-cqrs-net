namespace Domain
{
	using System;

	public sealed class Balance
	{
		public static Balance ZERO = Of(0.0);

		private readonly double _value;

		private Balance(double value)
		{
			_value = value;
		}

		public static Balance Of(double value)
		{
			return new Balance(value);
		}

		public Balance Add(Amount amountToAdd)
		{
			Amount amount = Amount.Of(_value).Add(amountToAdd);
			return new Balance(amount.Value);
		}

		public override bool Equals(object obj)
		{
			if (this == obj) return true;
			if (obj == null || GetType() != obj.GetType()) return false;

			Balance balance = (Balance)obj;

			return balance._value == _value;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine("Balance", _value);
		}

		public override string ToString()
		{
			return "Balance{" +
				"value=" + _value +
				'}';
		}
	}
}
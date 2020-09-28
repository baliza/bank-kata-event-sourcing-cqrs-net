namespace Domain
{
	using System;

	public sealed class Amount
	{
		private readonly double _value;

		private Amount(double value)
		{
			_value = value;
		}

		public double Value { get { return _value; } }
		public bool IsPositive { get { return Value > 0; } }

		public static Amount Of(double value)
		{
			return new Amount(value);
		}

		public Amount Add(Amount amount)
		{
			return new Amount(Value + amount.Value);
		}

		public override bool Equals(object obj)
		{
			if (this == obj) return true;
			if (obj == null || GetType() != obj.GetType()) return false;

			Amount amount = (Amount)obj;

			return double.Equals(amount.Value, Value);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine("Amount", _value);
		}

		public override string ToString()
		{
			return "Amount{" +
					"value=" + Value +
					'}';
		}
	}
}
namespace Domain
{
	using System;

	public static class Preconditions
	{
		public static void CheckArgumentIsTrue(bool condition, string argument)
		{
			if (!condition)
				throw new Exception(argument);
		}
	}
}
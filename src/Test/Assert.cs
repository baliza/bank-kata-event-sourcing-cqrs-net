using Domain.Event;
using System.Collections.Generic;

namespace Console.Test
{
	internal static class Assert
	{
		internal static void ThatAreEqual(object o1, object o2, string message)
		{
			if (o1.Equals(o2))
			{
				Terminal.WriteGreen(message);
			}
			else
			{
				Terminal.WriteRed(message);
			}
		}

		internal static void ContainsOnly<T>(List<T> list, T expected, string message)
		{
			if (list.Count == 1 && list[0].Equals(expected))
			{
				Terminal.WriteGreen(message);
			}
			else
			{
				Terminal.WriteRed(message);
			}
		}
	}
}
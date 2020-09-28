using System.Collections.Generic;
using System.Linq;

namespace Console.Test
{
	internal static class Assert
	{
		internal static void ThatAreEqual(object o1, object o2, string message)
		{
			PrintResult(o1.Equals(o2), message);
		}

		internal static void ContainsOnly<T>(List<T> list, T expected, string message)
		{
			PrintResult(list.Count == 1 && list[0].Equals(expected), message);
		}

		internal static void Contains<T>(List<T> list, T expected, string message)
		{
			var any = list.Any(x => list.Equals(x));
			PrintResult(any, message);
		}

		private static void PrintResult(bool result, string message)
		{
			if (result)
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
namespace Console.Test
{
	using System;

	internal static class Terminal
	{
		internal static void WriteGreen(string message)
		{
			global::System.Console.ForegroundColor = ConsoleColor.Green;
			global::System.Console.WriteLine(message + " GOOD");
		}

		internal static void WriteRed(string message)
		{
			global::System.Console.ForegroundColor = ConsoleColor.Red;
			global::System.Console.WriteLine(message + " WRONG");
		}
	}
}
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
	}
}
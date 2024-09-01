using System;
using System.Collections.Generic;
using System.Text;

namespace Requester
{
	public static class Report
	{
		public static void CreateCheckbox(bool state, string message)
		{
			Console.OutputEncoding = Encoding.UTF8;
			if (state)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write("[\u221A] ");
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write(message);
				Console.WriteLine();
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Write("[\u2718] ");
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write(message);
				Console.WriteLine();
			}

		}
	}
}

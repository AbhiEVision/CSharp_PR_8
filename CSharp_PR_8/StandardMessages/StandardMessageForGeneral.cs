namespace CSharp_PR_8.StandardMessages
{
    public static class StandardMessageForGeneral
	{
		public static void PrintEndingMessage()
		{
			ConsoleColorChange.MakeColorGreen();
			Printer.Print("========== Thanks for Visit us ==========");
			Console.ResetColor();
		}


		public static void PrintInvalidInput()
		{
			Printer.SkipLine();
			Printer.PrintError("Please choose Valid Option.");
			Printer.SkipLine();
		}

		public static void PrintStartUpMessage()
		{
			ConsoleColorChange.MakeColorGreen();
			Printer.Print("==========  Welcome To Library  ==========");
			Printer.Print("");
			Printer.Print(" 1. User");
			Printer.Print(" 2. Librarian");
			Printer.Print(" 3. Exit");
			Printer.SkipLine();
			ConsoleColorChange.MakeColorBlue();
		}

	}
}
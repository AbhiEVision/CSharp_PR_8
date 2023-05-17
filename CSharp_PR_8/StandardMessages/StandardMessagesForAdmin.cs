namespace CSharp_PR_8.StandardMessages
{
    public static class StandardMessagesForAdmin
	{
		public static void PrintHomePageWelcomeMessage(string _userName)
		{
			ConsoleColorChange.MakeColorGreen();
			Printer.Print($"=========== Welcome {_userName} ===========");
			Printer.SkipLine();
			Printer.Print(" 1. Add a book");
			Printer.Print(" 2. Remove a book");
			Printer.Print(" 3. List total books in Library");
			Printer.Print(" 4. List out total taken books");
			Printer.Print(" 5. Remove user");
			Printer.Print(" 6. Add user");
			Printer.Print(" 7. Change Password");
			Printer.Print(" 8. Clear console");
			Printer.Print(" 9. Logged Out");
		}

		public static void PrintWelcomeMessageOnSignUpPage()
		{
			Console.Clear();
			ConsoleColorChange.MakeColorGreen();
			Printer.Print("=========== Sign Up ===========");
		}

		public static void PrintWelcomeMessageOnLogInPage()
		{
			Console.Clear();
			ConsoleColorChange.MakeColorGreen();
			Printer.Print("=========== Log In ===========");
		}

		public static void PrintStartUpMessage()
		{
			ConsoleColorChange.MakeColorGreen();
			Printer.Print("========== Librarian ==========");
			Printer.Print("");
			Printer.Print(" 1. Login");
			Printer.Print(" 2. SignUp");
			Printer.Print(" 3. Exit");
			Printer.SkipLine();
			ConsoleColorChange.MakeColorBlue();
		}

		public static void PrintAddUserPageMessage()
		{
			Console.Clear();
			ConsoleColorChange.MakeColorGreen();
			Printer.Print("==========  Add User details  ==========");
		}
	}
}
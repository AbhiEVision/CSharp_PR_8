namespace CSharp_PR_8.StandardMessages
{
    public static class StandardMessagesForUser
    {
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

        public static void PrintHomePageWelcomeMessage(string _userName)
        {
			ConsoleColorChange.MakeColorGreen();
            Printer.Print($"=========== Welcome {_userName} ===========");
            Printer.SkipLine();
            Printer.Print(" 1. Borrow a book");
            Printer.Print(" 2. Return a book");
            Printer.Print(" 3. List out total available books");
            Printer.Print(" 4. List out total books");
            Printer.Print(" 5. List out borrowed books");
            Printer.Print(" 6. Change password");
            Printer.Print(" 7. Clear console");
            Printer.Print(" 8. Logged Out");
        }

        public static void PrintStartUpMessage()
        {
			ConsoleColorChange.MakeColorGreen();
            Printer.Print("========== User ==========");
            Printer.Print("");
            Printer.Print(" 1. Login");
            Printer.Print(" 2. SignUp");
            Printer.Print(" 3. Exit");
            Printer.SkipLine();
			ConsoleColorChange.MakeColorBlue();
        }
    }
}
